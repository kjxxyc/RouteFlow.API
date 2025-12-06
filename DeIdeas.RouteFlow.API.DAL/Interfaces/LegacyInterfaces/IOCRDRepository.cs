using DeIdeas.RouteFlow.API.DAL.Models.Legacy;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface IOCRDRepository
    {
        Task<IEnumerable<OCRD>> GetAllAsync();
        Task<OCRD?> GetByIdAsync(string cardCode);
    }
}