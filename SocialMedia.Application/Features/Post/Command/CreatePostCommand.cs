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
    public class CreatePostCommand : IRequest<PostDto>
    {

        public string Content { get; set; }

        public string UserId { get; set; }

        public List<IFormFile> Images { get; set; }



    }
}
