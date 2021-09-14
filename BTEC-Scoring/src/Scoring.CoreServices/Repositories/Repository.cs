using Microsoft.EntityFrameworkCore;
using Scoring.CoreServices.Extensions;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseEntity.DB;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Scoring.CoreServices.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = default;
        private DbSet<T> _entity = default;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T item)
        {
            await _entity.AddAsync(item);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _entity.FirstOrDefaultAsync(o => o.Id == id);
            _entity.Remove(item);
            return await SaveAsync();
        }

        public DbSet<T> Get()
        {
            return _entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(List<Expression<Func<T, object>>> includes)
        {
            return await _entity.IncludeAll(includes).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null)
        {
            return await _entity.Where(filter).IncludeAll(includes).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null)
        {
            return (await GetAsync(filter, includes)).FirstOrDefault();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            item.Id = id;
            _entity.Update(item);
            return await SaveAsync();
        }
    }
}
