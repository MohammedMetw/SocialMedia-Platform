using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Domain.Entities.posts;

namespace SocialMedia.Application.Interface
{
    public interface IPostRepository : IGeniricRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
    }
}
