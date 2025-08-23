namespace StopfinderIntegrator.Core
{
    public class DataIntegrator
    {
        private readonly IDataCollectionService _dataService;
        private readonly IEnumerable<IDataPublishingService> _publishers;

        public DataIntegrator(IDataCollectionService dataService, IEnumerable<IDataPublishingService> publishers)
        {
            _dataService = dataService;
            _publishers = publishers;
        }

        public async Task RunAsync()
        {
            // Example: get schedule for today and tomorrow

            var baseUrl = await _dataService.GetApiBaseUrlAsync();
            var token = await _dataService.AuthenticateAsync();
            var version = await _dataService.GetApiVersionAsync(token.Token);
            //var schedules = await _dataService.GetScheduleAsync(token.Token, version.ClientId, DateTime.Today, DateTime.Today.AddDays(1));
            var schedules = await _dataService.GetScheduleAsync(token.Token, version.ClientId, DateTime.Today.AddDays(2), DateTime.Today.AddDays(3));

            foreach (var day in schedules ?? Enumerable.Empty<DTO.ScheduleResponse>())
            {
                foreach (var student in day.StudentSchedules ?? Enumerable.Empty<DTO.StudentSchedule>())
                {
                    foreach (var trip in student.Trips ?? Enumerable.Empty<DTO.Trip>())
                    {
                        foreach (var publisher in _publishers)
                        {
                            if (trip.ToSchool == true)
                            {
                                await publisher.PublishPickupAsync(
                                    trip.BusNumber ?? string.Empty,
                                    trip.PickUpStopName ?? string.Empty,
                                    trip.PickUpTime ?? DateTime.MinValue,
                                    trip.DropOffStopName ?? string.Empty,
                                    trip.DropOffTime ?? DateTime.MinValue,
                                    student.FirstName + " " + student.LastName
                                );
                            }
                            else
                            {
                                await publisher.PublishDropoffAsync(
                                    trip.BusNumber ?? string.Empty,
                                    trip.PickUpStopName ?? string.Empty,
                                    trip.PickUpTime ?? DateTime.MinValue,
                                    trip.DropOffStopName ?? string.Empty,
                                    trip.DropOffTime ?? DateTime.MinValue,
                                    student.FirstName + " " + student.LastName
                                );
                            }
                        }
                    }
                }
            }
        }
    }
}
