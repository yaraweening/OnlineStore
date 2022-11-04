using DAL.Context;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class ReviewDAL : IReviewDAL
    {
        public Review CreateReview(Review review)
        {
            using (var context = new OnlineStoreContext())
            {
                if (ReviewExists(review.ReviewID))
                {
                    throw new Exception("This review id already exists");
                }

                if (!ProductExists(review.ProductID))
                {
                    throw new Exception("This product does not exist");
                }

                context.Add(review);
                context.SaveChanges();
                return review;
            }
        }

        public IEnumerable<Review> GetReviews()
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Reviews.ToList();
            }

            return null;
        }

        private static bool ReviewExists(string reviewID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Reviews.Any(e => e.ReviewID == reviewID);
            }
        }

        private static bool ProductExists(string productID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Products.Any(e => e.ProductID == productID);
            }
        }
    }
}
