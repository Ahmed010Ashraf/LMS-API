using Domain.Contracts;
using Domain.Entities;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Reposatories
{
    public class UniteOfWork(AppDbContext _context) : IUniteOfWork
    {

        private Dictionary<string, object> ReposatoriesHub = new ();
        public IGenericReposatory<TEntity> GetReposatory<TEntity>() where TEntity : BaseEntity
        {
            var RepoName = typeof(TEntity).Name;
            if (!ReposatoriesHub.ContainsKey(RepoName)) {
                ReposatoriesHub[RepoName] = new GenericReposatory<TEntity> (_context);
            }

            return (IGenericReposatory<TEntity>) ReposatoriesHub[RepoName];
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
