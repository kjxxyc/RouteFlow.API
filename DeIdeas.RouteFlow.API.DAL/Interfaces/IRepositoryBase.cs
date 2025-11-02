using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities records.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetAllAsync();


        /// <summary>
        /// Get all entities filtered by the specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetListWithFilterAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Get a entity filtered by the specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<TEntity?> GetSingleWithFilterAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Check if an entity meets the specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<bool> CheckWithConditionAsync(Expression<Func<TEntity, bool>> predicate, string? includeProperties = null);


        /// <summary>
        /// Get entity by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity?> FindByIdAsync(int id);


        public Task<TEntity?> FindById(string rol);


        /// <summary>
        /// Create a new record.
        /// </summary>
        /// <param name="entity">Entity to create</param>
        public void Create(TEntity entity);


        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public void Update(TEntity entity);


        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public void Delete(TEntity entity);


        /// <summary>
        /// Reload record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> ReloadAsync(TEntity entity);
    }
}