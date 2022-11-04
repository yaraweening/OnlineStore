using DAL.Context;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class ForumDAL : IForumDAL
    {
        public Forum CreateForum(Forum forum)
        {
            using (var context = new OnlineStoreContext())
            {
                context.Add(forum);
                context.SaveChanges();
                return forum;
            }
        }

        public IEnumerable<Forum> GetReviewsFromForums()
        {
            using (var context = new OnlineStoreContext())
            {
                Forum forum = context.Forums
                    .Select(o => new Forum
                    {
                        ForumID = o.ForumID,
                        Review = o.Review
                    }).First();

                return (IEnumerable<Forum>)forum;
            }

            return null;
        }
    }
}
