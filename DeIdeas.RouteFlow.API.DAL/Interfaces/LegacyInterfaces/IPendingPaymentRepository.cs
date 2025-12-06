using DeIdeas.RouteFlow.API.DAL.Models.Legacy;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface IPendingPaymentRepository
    {
        Task<IEnumerable<SAP_V_PendingPayment>> GetAllAsync();
    }
}