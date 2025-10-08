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
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery,PostDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDto> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(query.PostId);
            if (post == null)
            {
                throw new Exception("Post not found");

            }

            return new PostDto
            {


            };
            


        }







    }
}
