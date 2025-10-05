using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities.posts
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        public  required string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<PostImage> Images { get; set; } = new List<PostImage>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

        public required string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
