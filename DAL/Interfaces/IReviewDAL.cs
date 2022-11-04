using Models;

namespace DAL.Interfaces
{
    public interface IReviewDAL
    {
        Review CreateReview(Review review);
        IEnumerable<Review> GetReviews();
    }
}
