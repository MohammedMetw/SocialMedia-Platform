using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Post.Command
{
    public class UpdatePostCommand : IRequest<PostDto>
    {

        public int PostId { get; set; }
        public string Content { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<PostImageDto> ExistingImages { get; set; } = new List<PostImageDto>();
    }
}
