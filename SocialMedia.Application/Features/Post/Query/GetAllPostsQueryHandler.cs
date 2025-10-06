using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Interface;

namespace SocialMedia.Application.Features.Post.Query
{
    public class GetAllPostsQueryHandler: IRequestHandler<GetAllPostsQuery,IEnumerable<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<IEnumerable<PostDto>> Handle(GetAllPostsQuery query,CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetAllPostsAsync();


            var postDtos = posts.Select(p => new PostDto
            {
                Id = p.Id,
                Content = p.Content,
                CreatedDate = p.CreatedDate,
                AuthorfullName = $"{p.ApplicationUser.FirstName} {p.ApplicationUser.SecondName}",
                Images = p.Images.Select(img => new PostImageDto { Id = img.Id, ImagePath = img.ImagePath }).ToList(),
                ReactionCount = p.Reactions.Count(),
                Reactions = p.Reactions.Select(r => new ReactionDto { ReactionType = r.Reactiontype, UserName = $"{r.ApplicationUser.FirstName} {r.ApplicationUser.SecondName}" }).ToList()
                
            }).ToList();

            return postDtos;

        }
    }
}
