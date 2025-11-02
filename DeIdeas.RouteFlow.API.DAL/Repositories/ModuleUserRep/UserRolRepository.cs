using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep
{
    internal class UserRolRepository : RepositoryBaseApp<USR_UserRol>, IUserRolRepository
    {
        public UserRolRepository(AppDbContext context) : base(context)
        {
        }
    }
}
