using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep
{
    internal class ControlRepository : RepositoryBaseApp<USR_Control>, IControlRepository
    {
        public ControlRepository(AppDbContext context) : base(context)
        {
        }
    }
}
