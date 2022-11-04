using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Services.Interfaces;

namespace Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewDAL _reviewDAL;

        public ReviewService(IReviewDAL reviewDAL)
        {
            _reviewDAL = reviewDAL;
        }

        public Review CreateReview(Review review)
        {
            review = new Review()
            {
                ReviewID = review.ReviewID,
                ProductID = review.ProductID,
                ReviewText = review.ReviewText
            };

            review = _reviewDAL.CreateReview(review);

            return review;
        }

        public IActionResult GetReviews()
        {
            return (new ActionResult<IEnumerable<Review>>(_reviewDAL.GetReviews()) as IConvertToActionResult).Convert();
        }
    }
}
