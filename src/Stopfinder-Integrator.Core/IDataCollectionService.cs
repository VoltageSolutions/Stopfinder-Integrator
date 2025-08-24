
using StopfinderIntegrator.Core.Data;

namespace StopfinderIntegrator.Core
{
    public interface IDataCollectionService
    {
        Task<bool> Initialize();
        Task<IEnumerable<StudentSchedule>> GetScheduleAsync(DateTime start, DateTime end);
    }
}
