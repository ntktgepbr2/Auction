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

        public async Task<IReadOnlyCollection<TEntity>> GetAllByName(string name)
        {
            {
                var query = this.All.Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
                return await query.ToArrayAsync();
            }
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll()
        {
            return await this.All.ToListAsync();
        }

        public async Task<TEntity> GetEntity(Guid id)
        {
            var result = await _context.FindAsync<TEntity>(id);

            return result;
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

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContext() => await _context.SaveChangesAsync();

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var getEntity = await GetEntity(id);

            _context.Remove(getEntity);
        }
    }
}