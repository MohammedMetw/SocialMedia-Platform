using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IPostRepository PostRepository { get; }
        public IPostImageRepository PostImageRepository { get; }
        public IReactionRepository ReactionRepository { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
