using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
         IPostRepository PostRepository { get; }
         IPostImageRepository PostImageRepository { get; }
         IReactionRepository ReactionRepository { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
