using DeIdeas.RouteFlow.API.DAL.Models.Legacy;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface ISnapshotRepository
    {
        Task InsertAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default);
        Task<OINV_OCRD_Snapshot?> GetByDocumentoAsync(int noDocumento, CancellationToken ct = default);
        Task UpdateAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default);
        Task UpdatePasswordAsync(OINV_OCRD_Snapshot entity, CancellationToken ct = default);
    }
}