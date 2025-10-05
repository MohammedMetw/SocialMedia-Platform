using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Entities.posts;

namespace SocialMedia.Infrastructure.Persistence
{
    public class SocialMediaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; } 
        public DbSet<Reaction> Reactions { get; set; }
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reaction>()
                 .HasKey(r => new { r.ApplicationUserId, r.PostId }); // prevent many reaction of a user in same post

            builder.Entity<Reaction>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            builder.Entity<Reaction>()
                .HasOne(r => r.ApplicationUser)
                .WithMany(u => u.Reactions)
                .HasForeignKey(r => r.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }

    }
}
