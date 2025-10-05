using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities.posts
{
    public class PostImage
    {
        public int Id { get; set; }
        public required string ImagePath { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
