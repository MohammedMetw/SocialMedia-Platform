using SocialMedia.Domain.Entities.posts;

namespace SocialMedia.Application.Interface
{
    public interface IReactionRepository : IGeniricRepository<Reaction>
    {
       Task<IEnumerable<Reaction>> GetAllReactionPost(int postID);
    }
}