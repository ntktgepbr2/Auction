using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : DomainEntity
    {
        private readonly AuctionDbContext _context;

        protected RepositoryBase(AuctionDbContext context)
        {
            _context = context;
        }

        //public async Task<IReadOnlyCollection<TEntity>> GetAll(TEntity entity)
        //{
        //    try
        //    {
        //        var query = this.All.Where(x => x.Name.Contains(entity.Name, StringComparison.CurrentCultureIgnoreCase));
        //        return await query.ToArrayAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        //    }
        //}

        public async Task<IReadOnlyCollection<TEntity>> GetAllByName(string name)
        {
            try
            {
                var query = this.All.Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll()
        {
            try
            {
                return await this.All.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetEntity(Guid id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        /// <summary>
        /// Gets All entities.
        /// </summary>
        protected virtual IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var getEntity = await GetEntity(id);

            _context.Remove(getEntity);
        }
    }
}