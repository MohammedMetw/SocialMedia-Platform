using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Interface;
using SocialMedia.Domain.Entities.posts;
using SocialMedia.Infrastructure.Persistence;

namespace SocialMedia.Infrastructure.Repository
{
    public class PostRepository : GeniricRepository<Post>, IPostRepository
    {
        public PostRepository(SocialMediaDbContext context) : base(context)
        {

        }


        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts
                        .Include(p => p.ApplicationUser)   
                        .Include(p => p.Images)             
                        .Include(p => p.Reactions)          
                        .ThenInclude(r => r.ApplicationUser) 
                        .AsNoTracking()
                        .OrderByDescending(p => p.CreatedDate)
                        .ToListAsync();
        }
        public async Task<Post> GetPostWithDetailsAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.ApplicationUser)
                .Include(p => p.Images)
                .Include(p => p.Reactions)
                    .ThenInclude(r => r.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

