namespace StopfinderIntegrator.Core
{
    public interface IDataPublishingService
    {
        Task PublishPickupAsync(
            StopfinderIntegrator.Core.Data.Trip trip,
            string? childName = null
        );

        Task PublishDropoffAsync(
            StopfinderIntegrator.Core.Data.Trip trip,
            string? childName = null
        );
    }
}
