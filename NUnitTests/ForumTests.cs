namespace NUnitTests
{
    public class ForumTests
    {
        private List<Forum> MockForumList;
        private Forum Forum;

        [SetUp]
        public void Setup()
        {
            MockForumList = new List<Forum>();
            Forum forum = new Forum();
            forum.ForumID = "Forum-01";
            forum.Review = "I am very satisfied with the new MSI laptop.";

            MockForumList.Add(forum);
        }

        [Test]
        public void Create_Forum_Should_Return_One_Forum()
        {
            //arrange
            var forum = MockForumList.First();
            var dalMock = new Mock<IForumDAL>();
            dalMock.Setup(x => x.CreateForum(It.IsAny<Forum>())).Returns(forum);

            //act
            var mockedDal = dalMock.Object;
            var mockedForum = mockedDal.CreateForum(forum);

            //assert
            Assert.IsNotNull(mockedForum);
            Assert.IsInstanceOf(typeof(Forum), mockedForum);
            Assert.That(mockedForum.ForumID, Is.EqualTo(forum.ForumID));
        }

        [TearDown]
        public void TestCleanUp()
        {
            MockForumList = null;
            Forum = null;
        }
    }
}
