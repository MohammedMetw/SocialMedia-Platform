using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Application.Interface;
using SocialMedia.Infrastructure.Persistence;

namespace SocialMedia.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaDbContext _context;
        public IPostRepository PostRepository { get; }
        public IPostImageRepository PostImageRepository { get ; }
        public IReactionRepository ReactionRepository { get ; }

        public UnitOfWork(SocialMediaDbContext context)
        {
            _context = context;
            PostRepository = new PostRepository(_context);
            PostImageRepository = new PostImageRepository(_context);
            ReactionRepository = new ReactionRepository(_context);

        }
        

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
