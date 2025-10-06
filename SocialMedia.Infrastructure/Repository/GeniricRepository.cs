using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Interface;
using SocialMedia.Infrastructure.Persistence;

namespace SocialMedia.Infrastructure.Repository
{
    public class GeniricRepository<T> : IGeniricRepository<T> where T : class
    {
        protected readonly SocialMediaDbContext _context;
        public GeniricRepository(SocialMediaDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
             _context.Set<T>().Remove(item);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int Id)
        {
           return await _context.Set<T>().FindAsync(Id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
