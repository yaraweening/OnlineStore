using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IReviewService
    {
        Review CreateReview(Review forum);
        IActionResult GetReviews();
    }
}
