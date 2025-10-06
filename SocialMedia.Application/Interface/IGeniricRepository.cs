using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Interface
{
    public interface IGeniricRepository<T> where T : class
    {
        Task AddAsync(T item);

        void Update(T item);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        void Delete(T item);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int Id);
    }
}
