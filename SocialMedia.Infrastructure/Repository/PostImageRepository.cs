using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Application.Interface;
using SocialMedia.Domain.Entities.posts;
using SocialMedia.Infrastructure.Persistence;

namespace SocialMedia.Infrastructure.Repository
{
    public class PostImageRepository : GeniricRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(SocialMediaDbContext context):base(context) 
        {
            
        }
    }
}
