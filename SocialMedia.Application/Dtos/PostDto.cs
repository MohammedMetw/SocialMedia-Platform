using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorfullName { get; set; }
        public List<PostImageDto> Images { get; set; }
        public List<ReactionDto> Reactions { get; set; }
        public int ReactionCount { get; set; }
    }
}
