using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMedia.Application.Features.Post.Query;

namespace SocialMedia.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return View(result);
        }
    }
}
