namespace TownSystem.Services.Data.Contracts
{
    using System.Linq;
    using TownSystem.Models;

    public interface ILikesService
    {
        IQueryable<Like> AllLikesForPost(int postId);

        void LikePost(int postId, string username);

        void DislikePost(int postId, string username);

        bool PostIsLikedByUser(int postId, string username);
    }
}
