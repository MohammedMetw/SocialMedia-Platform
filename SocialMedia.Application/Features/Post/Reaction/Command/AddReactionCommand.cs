using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SocialMedia.Application.Features.Reaction.Command
{
    public class AddReactionCommand : IRequest<bool>
    {
        public int PostId { get; set; }
        public string ReactionType { get; set; } // "Like", "Love", etc.
        public string UserId { get; set; }
    }
}
