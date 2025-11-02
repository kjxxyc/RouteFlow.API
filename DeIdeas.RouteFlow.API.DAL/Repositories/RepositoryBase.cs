using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeIdeas.RouteFlow.API.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // fields
        private readonly LegacyContext _context;

        // Propertys
        protected LegacyContext Context => _context;

        public RepositoryBase(LegacyContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> FindById(string rol)
        {
            return await _context.Set<TEntity>().FindAsync(rol);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListWithFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> ReloadAsync(TEntity entity)
        {
            await _context.Entry(entity).ReloadAsync();

            return entity;
        }

        public async Task<TEntity?> GetSingleWithFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> CheckWithConditionAsync(Expression<Func<TEntity, bool>> predicate, string? includeProperties = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties)) 
            {
                foreach (var prop in includeProperties.Split(","))
                {
                    query = query.Include(prop);
                }
            }

            return await query.AnyAsync(predicate);
        }
    }
}
