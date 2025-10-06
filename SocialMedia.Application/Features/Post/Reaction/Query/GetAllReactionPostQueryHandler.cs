using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Interface;

namespace SocialMedia.Application.Features.Post.Reaction.Query
{
    public class GetAllReactionPostQueryHandler : IRequestHandler<GetAllReactionPostQuery, IEnumerable<ReactionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllReactionPostQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReactionDto>> Handle(GetAllReactionPostQuery request, CancellationToken cancellationToken)
        {
            var reactions= await _unitOfWork.ReactionRepository.GetAllReactionPost(request.PostId);
            var result = reactions.Select(r => new ReactionDto
            {
                ReactionType = r.Reactiontype,
                UserName = $"{r.ApplicationUser.FirstName} {r.ApplicationUser.SecondName}"
            });

            return result;

        }
    }
}
