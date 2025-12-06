using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        // Legacy read-only + snapshot insert
        IOCRDRepository OCRD { get; }
        IOINVRepository OINV { get; }
        IPendingPassRepository PendingPass { get; }
        IPendingPaymentRepository PendingPayment { get; }
        ISnapshotRepository Snapshot { get; }
        IRutaRepository Ruta { get; }

        // Module User
        public ITypeUserRepository TypeUser { get; }
        public IDetTypeUserRepository DetTypeUser { get; }
        public IUserRepository USR_User { get; }
        public IConfigRepository USR_Config { get; }
        public IRolRepository USR_Rol { get; }
        public IUserRolRepository USR_UserRol { get; }
        public IControlRepository USR_Control { get; }
        public IControlRolRepository USR_ControlRol { get; }

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}
