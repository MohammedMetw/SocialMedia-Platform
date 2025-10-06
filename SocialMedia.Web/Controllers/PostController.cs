using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMedia.Application.Features.Post.Query;
using SocialMedia.Application.Features.Post.Command;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Domain.Entities;
using SocialMedia.Application.Features.Reaction.Command;
using SocialMedia.Application.Features.Post.Reaction.Query;

namespace SocialMedia.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(IMediator mediator,UserManager<ApplicationUser> userManager)  
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return View(result);
        }


        [HttpGet]
        public IActionResult CreatePost()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(CreatePostCommand command)
        {
            command.UserId = _userManager.GetUserId(User);
            var result = await _mediator.Send(command);
            return RedirectToAction(nameof(GetAllPosts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReaction(int postId, string reactionType)
        {
            var command = new AddReactionCommand
            {
                PostId = postId,
                ReactionType = reactionType,
                UserId = _userManager.GetUserId(User) 
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(GetAllPosts));
        }

        [HttpGet]
        public async Task<IActionResult> GetReactionsForPost(int postId)
        {
            var query = new GetAllReactionPostQuery { PostId = postId };
            var reactions = await _mediator.Send(query);

            return Json(reactions);
        }

    }
}
