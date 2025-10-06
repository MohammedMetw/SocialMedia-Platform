using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMedia.Application.Features.Post.Query;
using SocialMedia.Application.Features.Post.Command;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Domain.Entities;

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
    }
}
