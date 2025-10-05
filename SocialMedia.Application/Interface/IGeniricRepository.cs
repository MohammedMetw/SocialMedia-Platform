using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Interface
{
    public interface IGeniricRepository<T> where T : class
    {
        Task AddAsync(T item);

        void Update(T item);

        void Delete(T item);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int Id);
    }
}
