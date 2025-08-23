namespace StopfinderIntegrator.Core
{
    public interface IDataPublishingService
    {
        Task PublishPickupAsync(
            string busNumber,
            string pickUpStopName,
            DateTime pickUpTime,
            string dropOffStopName,
            DateTime dropOffTime,
            string? childName = null
        );

        Task PublishDropoffAsync(
            string busNumber,
            string pickUpStopName,
            DateTime pickUpTime,
            string dropOffStopName,
            DateTime dropOffTime,
            string? childName = null
        );
    }
}
