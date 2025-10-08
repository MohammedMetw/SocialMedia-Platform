using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Interface;

namespace SocialMedia.Application.Features.Post.Command
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IFileStorageService _fileStorageService;
        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService featureService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = featureService;
        }

        public async Task<PostDto> Handle( UpdatePostCommand command, CancellationToken cancellationToken )
        {
            var post = await _unitOfWork.PostRepository.GetPostWithDetailsAsync(command.PostId);
            post.Content = command.Content;
           

            if (command.Images != null && command.Images.Any())
            {
                foreach (var imageFile in command.Images)
                {
                    var imageUrl = await _fileStorageService.SaveFileAsync(imageFile, "posts");
                    if (imageUrl != null)
                    {
                        post.Images.Add(new SocialMedia.Domain.Entities.posts.PostImage { ImagePath = imageUrl, PostId = post.Id });
                    }
                }
            }
             _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                CreatedDate = post.CreatedDate
            };


        }




    }
}
