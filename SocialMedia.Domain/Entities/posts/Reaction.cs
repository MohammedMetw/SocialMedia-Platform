using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities.posts
{
    public class Reaction
    {
      
        public string Reactiontype { get; set; }

        public required string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public required int PostId { get; set; }
        public Post Post { get; set; }
    }
}
