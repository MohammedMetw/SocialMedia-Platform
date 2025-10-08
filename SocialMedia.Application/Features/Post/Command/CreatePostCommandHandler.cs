using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Interface;
using SocialMedia.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using SocialMedia.Domain.Entities.posts;

namespace SocialMedia.Application.Features.Post.Command
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService; 

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<PostDto> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var post = new SocialMedia.Domain.Entities.posts.Post
            {
                Content = command.Content,
                ApplicationUserId = command.UserId,
            };
           
            if (command.Images != null && command.Images.Any())
            {
                foreach (var imageFile in command.Images)
                {
                    var imageUrl = await _fileStorageService.SaveFileAsync(imageFile, "posts");
                    if (imageUrl != null)
                    {
                        post.Images.Add(new SocialMedia.Domain.Entities.posts.PostImage { ImagePath = imageUrl,PostId = post.Id });
                    }
                }
            }

            await _unitOfWork.PostRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

          
            return new PostDto 
            { 
                Id = post.Id,
                Content = post.Content 
            };
        }
    }
}
