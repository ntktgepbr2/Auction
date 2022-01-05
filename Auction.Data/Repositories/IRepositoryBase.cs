using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Task<IReadOnlyCollection<TEntity>> GetAll(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> GetAllByName(string name);
        Task<IReadOnlyCollection<TEntity>> GetAll();
        Task<TEntity> GetEntity(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}