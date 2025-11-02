using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep
{
    internal class DetTypeUserRepository : RepositoryBaseApp<USR_DetTypeUser>, IDetTypeUserRepository
    {
        public DetTypeUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
