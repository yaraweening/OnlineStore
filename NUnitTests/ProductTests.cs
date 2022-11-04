namespace NUnitTests
{
    public class ProductTests
    {
        private List<Product> MockProductList;
        private Product Product;

        [SetUp]
        public void Setup()
        {
            MockProductList = new List<Product>();
            Product Product = new Product();
            Product.ProductID = "Product-01";
            Product.Name = "MSI laptop";
            Product.Description = "MSI Laptop has a fast processor for gaming";
            Product.Image = "msi.jpg";

            MockProductList.Add(Product);
        }

        [Test]
        public void Create_Product_Should_Return_One_Product()
        {
            //arrange
            var product = MockProductList.First();
            var dalMock = new Mock<IProductDAL>();
            dalMock.Setup(x => x.CreateProduct(It.IsAny<Product>())).Returns(product);

            //act
            var mockedDal = dalMock.Object;
            var mockedProduct = mockedDal.CreateProduct(product);

            //assert
            Assert.IsNotNull(mockedProduct);
            Assert.IsInstanceOf(typeof(Product), mockedProduct);
            Assert.That(mockedProduct.ProductID, Is.EqualTo(product.ProductID));
        }

        [Test]
        public void Get_Products_Should_Return_All_Products()
        {
            //arrange
            var dalMock = new Mock<IProductDAL>();
            dalMock.Setup(x => x.GetProducts());

            //act
            var mockedDal = dalMock.Object;
            var mockedProduct = mockedDal.GetProducts();

            //assert
            Assert.IsNotNull(mockedProduct);
        }

        [Test]
        public void Get_By_ProductID_Should_Return_One_Product()
        {
            //arrange
            var dalMock = new Mock<IProductDAL>();
            dalMock.Setup(x => x.GetProductById(It.IsAny<string>())).Returns((string s) => MockProductList.Where(x => x.ProductID == s).Single());

            //act
            var mockedDal = dalMock.Object;
            var mockedProduct = mockedDal.GetProductById("Product-01");

            //assert
            Assert.That(mockedProduct.ProductID, Is.EqualTo("Product-01"));
        }

        [TearDown]
        public void TestCleanUp()
        {
            MockProductList = null;
            Product = null;
        }
    }
}
