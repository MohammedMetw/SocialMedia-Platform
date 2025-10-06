using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMedia.Application.Interface;
using SocialMedia.Domain.Entities.posts;

namespace SocialMedia.Application.Features.Reaction.Command
{
    public class AddReactionCommandHandler : IRequestHandler<AddReactionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddReactionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddReactionCommand command, CancellationToken cancellationToken)
        {
            
            var existingReaction = await _unitOfWork.ReactionRepository
                .GetAsync(r => r.ApplicationUserId == command.UserId && r.PostId == command.PostId);

            if (existingReaction == null)
            {
            
                var newReaction = new SocialMedia.Domain.Entities.posts.Reaction
                {
                    PostId = command.PostId,
                    ApplicationUserId = command.UserId,
                    Reactiontype = command.ReactionType
                };
                await _unitOfWork.ReactionRepository.AddAsync(newReaction);
            }
            else if (existingReaction.Reactiontype == command.ReactionType)
            {
                _unitOfWork.ReactionRepository.Delete(existingReaction);
            }
            else
            {
                // User is changing their reaction
                existingReaction.Reactiontype = command.ReactionType;
                _unitOfWork.ReactionRepository.Update(existingReaction);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
