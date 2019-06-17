using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);
        Task<IEnumerable<T>> Read();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
