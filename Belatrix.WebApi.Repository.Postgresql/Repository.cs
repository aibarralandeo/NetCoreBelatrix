using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BelatrixDbContext belatrixDbContext;

        public Repository(BelatrixDbContext belatrixDbContext)
        {
            this.belatrixDbContext = belatrixDbContext;
        }

        public async Task<int> Create(T entity)
        {
            belatrixDbContext.Set<T>().Add(entity);
            return await belatrixDbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            belatrixDbContext.Set<T>().Remove(entity);
            return await belatrixDbContext.SaveChangesAsync() > 0;
        }
        
        public async Task<IEnumerable<T>> Read()
        {
            return await belatrixDbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            belatrixDbContext.Set<T>().Attach(entity).DetectChanges();
            return await belatrixDbContext.SaveChangesAsync() > 0;
        }
    }
}
