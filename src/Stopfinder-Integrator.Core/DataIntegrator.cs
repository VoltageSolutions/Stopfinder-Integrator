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
            await _dataService.Initialize();

            var students = await _dataService.GetScheduleAsync(DateTime.Today.AddDays(2), DateTime.Today.AddDays(3));

            foreach (var student in students ?? Enumerable.Empty<Data.StudentSchedule>())
            {
                foreach (var trip in student.Trips ?? Enumerable.Empty<Data.Trip>())
                {
                    foreach (var publisher in _publishers)
                    {
                        // If you want to distinguish pickup/dropoff, you may need to add a property to Data.Trip
                        // For now, treat all as pickup if PickUpTime is before DropOffTime, else dropoff
                        if (trip.PickUpTime.HasValue && trip.DropOffTime.HasValue && trip.PickUpTime <= trip.DropOffTime)
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
