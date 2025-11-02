using DeIdeas.RouteFlow.API.DAL.Interfaces.RMHInterfaces;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        //public IRepFileSBF repFileSBF { get; }
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
