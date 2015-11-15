namespace TownSystem.Services.Data
{
    using System;
    using System.Linq;
    using TownSystem.Models;
    using TownSystem.Services.Data.Contracts;

    public class LikesService : ILikesService
    {


        public IQueryable<Like> AllLikesForPost(int postId)
        {
            throw new NotImplementedException();
        }

        public int LikePost(int postId, string username)
        {
            throw new NotImplementedException();
        }

        public int DislikePost(int postId, string username)
        {
            throw new NotImplementedException();
        }

        public bool PostIsLikedByUser(int postId, string username)
        {
            throw new NotImplementedException();
        }
    }
}
