using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Reposatories
{
    public class GenericReposatory<TEntity>(AppDbContext _DbContext) : IGenericReposatory<TEntity> where TEntity : BaseEntity
    {


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking = false)
        {
            if (AsNoTracking)
            {
                return await _DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            else
            {
                return await _DbContext.Set<TEntity>().ToListAsync();

            }
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }


        public async Task AddAsync(TEntity entity)
        {
            await _DbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _DbContext.Remove(entity);
        }

   

        public void Update(TEntity entity)
        {
            _DbContext.Update(entity);
        }
    }
}
