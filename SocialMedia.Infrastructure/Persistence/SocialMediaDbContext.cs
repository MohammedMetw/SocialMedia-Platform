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

            // --- Define Primary Keys ---
            builder.Entity<Reaction>()
                   .HasKey(r => new { r.ApplicationUserId, r.PostId });

            // --- Define Relationships ---

            // When a User is deleted, their Posts are deleted.
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.Entity<Post>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction); 

            // When a Post is deleted, its children are deleted.
            builder.Entity<Post>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Post)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                .HasMany(p => p.Reactions)
                .WithOne(r => r.Post)
                .OnDelete(DeleteBehavior.Cascade);

          

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Reactions)
                .WithOne(r => r.ApplicationUser)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
