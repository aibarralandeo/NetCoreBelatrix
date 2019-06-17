using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly BelatrixDbContext dataBase;
        public Repository(BelatrixDbContext db)
        {
            dataBase = db;
        }
        
        public Task<int> Create(T entity)
        {
            dataBase.AddAsync(entity);
            return dataBase.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            dataBase.Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return await dataBase.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await dataBase.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            dataBase.Update(entity);
            return await dataBase.SaveChangesAsync() > 0;
        }
    }
}
