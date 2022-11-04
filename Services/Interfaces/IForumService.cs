using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IForumService
    {
        Forum CreateForum(Forum forum);
        IActionResult GetReviewsFromForums();
    }
}
