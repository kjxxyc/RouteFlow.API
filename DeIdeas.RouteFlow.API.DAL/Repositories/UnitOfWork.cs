using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Repositories.ModuleLegacy;
using DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep;

namespace DeIdeas.RouteFlow.API.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LegacyContext _legacyContext = default!;
        private readonly AppDbContext _appContext = default!;

        // Legacy repositories
        private IOCRDRepository _ocrd = default!;
        private IOINVRepository _oinv = default!;
        private IPendingPassRepository _pendingPass = default!;
        private IPendingPaymentRepository _pendingPayment = default!;
        private ISnapshotRepository _snapshot = default!;
        private IRutaRepository _ruta = default!;

        // ModuleUser repositories
        private ITypeUserRepository _typeUser = default!;
        private IDetTypeUserRepository _detTypeUser = default!;
        private IUserRepository _usrUser = default!;
        private IConfigRepository _usrConfig = default!;
        private IRolRepository _usrRol = default!;
        private IUserRolRepository _usrUserRol = default!;
        private IControlRepository _usrControl = default!;
        private IControlRolRepository _usrControlRol = default!;

        // Constructor
        public UnitOfWork(LegacyContext legacyContext, AppDbContext appContext)
        {
            _legacyContext = legacyContext;
            _appContext = appContext;
        }

        // Legacy props
        public IOCRDRepository OCRD => _ocrd ??= new OCRDRepository(_legacyContext);
        public IOINVRepository OINV => _oinv ??= new OINVRepository(_legacyContext);
        public IPendingPassRepository PendingPass => _pendingPass ??= new PendingPassRepository(_legacyContext);
        public IPendingPaymentRepository PendingPayment => _pendingPayment ??= new PendingPaymentRepository(_legacyContext);
        public ISnapshotRepository Snapshot => _snapshot ??= new SnapshotRepository(_legacyContext);
        public IRutaRepository Ruta => _ruta ??= new RutaRepository(_legacyContext);

        // ModuleUser props
        public ITypeUserRepository TypeUser => _typeUser ??= new TypeUserRepository(_appContext);
        public IDetTypeUserRepository DetTypeUser => _detTypeUser ??= new DetTypeUserRepository(_appContext);
        public IUserRepository USR_User => _usrUser ??= new UserRepository(_appContext);
        public IConfigRepository USR_Config => _usrConfig ??= new ConfigRepository(_appContext);
        public IRolRepository USR_Rol => _usrRol ??= new RolRepository(_appContext);
        public IUserRolRepository USR_UserRol => _usrUserRol ??= new UserRolRepository(_appContext);
        public IControlRepository USR_Control => _usrControl ??= new ControlRepository(_appContext);
        public IControlRolRepository USR_ControlRol => _usrControlRol ??= new ControlRolRepository(_appContext);

        // Methods
        public async Task<int> SaveChangesAsync()
        {
            return await _appContext.SaveChangesAsync();
        }
    }
}
