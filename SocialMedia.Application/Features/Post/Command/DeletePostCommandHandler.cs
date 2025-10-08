using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualBasic;
using SocialMedia.Application.Interface;

namespace SocialMedia.Application.Features.Post.Command
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;
        public DeletePostCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle (DeletePostCommand command, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetPostWithDetailsAsync (command.PostId);
            if (post == null)
            {
                throw new Exception("Post not found");
            }
            if (post.Images != null && post.Images.Any())
            {
                foreach (var image in post.Images)
                {
                    _fileStorageService.DeleteFile(image.ImagePath);
                }
            }
            _unitOfWork.PostRepository.Delete(post);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;


        }


    }
}
