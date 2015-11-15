namespace TownSystem.Services.Data.Contracts
{
    using System.Linq;
    using TownSystem.Models;

    public interface ILikesService
    {
        IQueryable<Like> AllLikesForPost(int postId);

        int LikePost(int postId, string username);

        int DislikePost(int postId, string username);

        bool PostIsLikedByUser(int postId, string username);
    }
}
