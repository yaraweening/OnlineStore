using Models;

namespace DAL.Interfaces
{
    public interface IForumDAL
    {
        Forum CreateForum(Forum forum);
        IEnumerable<Forum> GetReviewsFromForums();
    }
}
