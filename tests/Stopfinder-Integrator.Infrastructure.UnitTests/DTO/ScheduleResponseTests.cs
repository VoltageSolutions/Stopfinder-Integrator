using StopfinderIntegrator.Infrastructure.DTO;
using System.Text.Json;

namespace StopfinderIntegrator.Infrastructure.UnitTests.DTO
{
    public class ScheduleResponseTests
    {
        [Fact]
        public void CanSerializeAndDeserialize_ScheduleResponse()
        {
            var schedule = new ScheduleResponse(
                DateTime.Today,
                new List<StudentSchedule>
                {
                    new StudentSchedule(
                        true, 1, 2, "LID", "First", "Last", "G", "School", 1.1, 2.2, 3.3, 4.4, null, null, 5, true,
                        new List<Trip>
                        {
                            new Trip("Trip1", 1, "Bus1", "PU", 1.1, 1, 2.2, DateTime.Now, "DO", 3.3, 4.4, 2, DateTime.Now, true, false, false, "Alias", 0, 1, DateTime.Now, DateTime.Now, 1)
                        },
                        true, true, true, false, true, false, true, 10, 10, 67, 1, -240.0, true, false, 4012947, true, true, false,
                        new MapSettings(
                            new Extent(1,2,3,4,new SpatialReference(4326)), -83.7, 41.6)
                    )
                }
            );

            var json = JsonSerializer.Serialize(schedule);
            var deserialized = JsonSerializer.Deserialize<ScheduleResponse>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(schedule.Date, deserialized.Date);
            Assert.NotNull(deserialized.StudentSchedules);
            Assert.Single(deserialized.StudentSchedules);
        }
    }
}
