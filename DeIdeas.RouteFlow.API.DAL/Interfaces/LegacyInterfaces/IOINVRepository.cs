using DeIdeas.RouteFlow.API.DAL.Models.Legacy;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface IOINVRepository
    {
        Task<IEnumerable<OINV>> GetAllAsync();
        Task<OINV?> GetByIdAsync(int docEntry);
    }
}