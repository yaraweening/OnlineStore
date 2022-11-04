using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Services.Interfaces;

namespace Services
{
    public class ForumService : IForumService
    {
        private readonly IForumDAL _forumDAL;

        public ForumService(IForumDAL forumDAL)
        {
            _forumDAL = forumDAL;
        }

        public Forum CreateForum(Forum forum)
        {
            forum = new Forum()
            {
                ForumID = forum.ForumID,
                Review = forum.Review
            };

            forum = _forumDAL.CreateForum(forum);

            return forum;
        }

        public IActionResult GetReviewsFromForums()
        {
            return (new ActionResult<IEnumerable<Forum>>(_forumDAL.GetReviewsFromForums()) as IConvertToActionResult).Convert();
        }
    }
}
