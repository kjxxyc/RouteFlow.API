using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.RMHInterfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep;

namespace DeIdeas.RouteFlow.API.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // Fields
        private readonly LegacyContext _legacyContext = default!;
        private readonly AppDbContext _appContext = default!;
        //private IRepFileSBF _repFileSBF = default!;

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

        // Properties 
        //public IRepFileSBF repFileSBF => _repFileSBF ??= new RepFileDropSBFRepository(_legacyContext);
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
