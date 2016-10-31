using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess 
{
    public class PostRepository : Repository<PB_POSTS>
    {
        public List<PB_POSTS> GetListOfTimelinePosts(int id)
        {
            using ( var context =  new PasteBookEntities())
            {
                var result = context.PB_POSTS
                .Include("PB_COMMENTS.PB_USER")
                .Include("PB_COMMENTS")
                .Include("PB_LIKES")
                .Include("PB_LIKES.PB_USER")
                .Include("PB_NOTIFICATION")
                .Include("PB_USER")
                .Include("PB_USER1")
                .Where(x => x.PROFILE_OWNER_ID == id)
                .OrderByDescending(x => x.CREATED_DATE).Take(100)
                .ToList();
                return result;
            }
        }

        public List<PB_POSTS> GetListOfNewsFeedPosts(List<int> UserIDs)
        {
            using(var context = new PasteBookEntities())
            {
                var result = context.PB_POSTS
                 .Include("PB_COMMENTS.PB_USER")
                .Include("PB_COMMENTS")
                .Include("PB_LIKES")
                .Include("PB_LIKES.PB_USER")
                .Include("PB_NOTIFICATION")
                .Include("PB_USER")
                .Include("PB_USER1")
                .Where(x => UserIDs.Contains(x.POSTER_ID))
                .OrderByDescending(x => x.CREATED_DATE)
                .ToList();
                return result;
            }
        }
        public PB_POSTS GetPost(int postId)
        {
            using (var context = new PasteBookEntities())
            {
                var result = context.PB_POSTS
                 .Include("PB_COMMENTS.PB_USER")
                .Include("PB_COMMENTS")
                .Include("PB_LIKES")
                .Include("PB_LIKES.PB_USER")
                .Include("PB_NOTIFICATION")
                .Include("PB_USER")
                .Include("PB_USER1")
                .Where(x => x.ID == postId)
                .Single();
                return result;
            }
        }
    }
}
