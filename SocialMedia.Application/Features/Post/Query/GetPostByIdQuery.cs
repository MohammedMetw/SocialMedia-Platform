using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Post.Query
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public int PostId { get; set; }
    }
}
