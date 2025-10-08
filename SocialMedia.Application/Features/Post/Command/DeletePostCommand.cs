using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SocialMedia.Application.Features.Post.Command
{
    public class DeletePostCommand :IRequest<Unit>
    {
        public int PostId { get; set; }
    }
}
