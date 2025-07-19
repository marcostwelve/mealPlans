using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(Expression<Func<T, bool>>? filter = null);
        Task<bool> SaveAsync();
    }
}
