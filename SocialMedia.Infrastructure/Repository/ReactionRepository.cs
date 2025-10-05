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
    public class ReactionRepository : GeniricRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(SocialMediaDbContext context):base(context) 
        {
            
        }
    }
}
