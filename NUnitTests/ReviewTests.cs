namespace NUnitTests
{
    public class ReviewTests
    {
        private List<Review> MockReviewList;
        private Review Review;

        [SetUp]
        public void Setup()
        {
            MockReviewList = new List<Review>();
            Review review = new Review();
            review.ReviewID = "Review-01";
            review.ReviewID = "Product-01";
            review.ReviewText = "I am very satisfied with the new MSI laptop.";

            MockReviewList.Add(review);
        }

        [Test]
        public void Create_Review_Should_Return_One_Review()
        {
            //arrange
            var review = MockReviewList.First();
            var dalMock = new Mock<IReviewDAL>();
            dalMock.Setup(x => x.CreateReview(It.IsAny<Review>())).Returns(review);

            //act
            var mockedDal = dalMock.Object;
            var mockedReview = mockedDal.CreateReview(review);

            //assert
            Assert.IsNotNull(mockedReview);
            Assert.IsInstanceOf(typeof(Review), mockedReview);
            Assert.That(mockedReview.ReviewID, Is.EqualTo(review.ReviewID));
        }

        [Test]
        public void Get_Reviews_Should_Return_All_Reviews()
        {
            //arrange
            var dalMock = new Mock<IReviewDAL>();
            dalMock.Setup(x => x.GetReviews());

            //act
            var mockedDal = dalMock.Object;
            var mockedReview = mockedDal.GetReviews();

            //assert
            Assert.IsNotNull(mockedReview);
        }

        [TearDown]
        public void TestCleanUp()
        {
            MockReviewList = null;
            Review = null;
        }
    }
}
