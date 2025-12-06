using DeIdeas.RouteFlow.API.DAL.Models.Routing;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface IRutaRepository
    {
        Task InsertAsync(Ruta entity, CancellationToken ct = default);
        Task InsertDetRutaAsync(DetRuta det, CancellationToken ct = default);
        Task<bool> DetRutaExistsAsync(int noDocumento, CancellationToken ct = default);
        Task AssignRutaAsync(int rutaId, string usuarioAsignado, CancellationToken ct = default);
        Task<IEnumerable<object>> GetDetRutasForUserAsync(string usuario, string? filter = null, CancellationToken ct = default);
    }
}