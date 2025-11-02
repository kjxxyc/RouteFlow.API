using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces.UserInterfaces;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;

namespace DeIdeas.RouteFlow.API.DAL.Repositories.ModuleUserRep
{
    internal class TypeUserRepository : RepositoryBaseApp<USR_TypeUser>, ITypeUserRepository
    {
        public TypeUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}