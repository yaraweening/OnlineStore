namespace NUnitTests
{
    public class OrderTests
    {
        private List<Order> MockOrderList;
        private Order Order;

        [SetUp]
        public void Setup()
        {
            MockOrderList = new List<Order>();
            Order Order = new Order();
            Order.OrderID = "Order-01";
            Order.ProductID = "Product-01";
            Order.OrderDate = new DateTime(2022, 12, 24);
            Order.ShippingDate = new DateTime(2022, 12, 30);
            Order.Status = "Shipped";

            MockOrderList.Add(Order);
        }

        [Test]
        public void Create_Order_Should_Return_One_Order()
        {
            //arrange
            var order = MockOrderList.First();
            var dalMock = new Mock<IOrderDAL>();
            dalMock.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(order);

            //act
            var mockedDal = dalMock.Object;
            var mockedOrder = mockedDal.CreateOrder(order);

            //assert
            Assert.IsNotNull(mockedOrder);
            Assert.IsInstanceOf(typeof(Order), mockedOrder);
            Assert.That(mockedOrder.OrderID, Is.EqualTo(order.OrderID));
        }

        [Test]
        public void Get_By_OrderID_Should_Return_One_Order()
        {
            //arrange
            var dalMock = new Mock<IOrderDAL>();
            dalMock.Setup(x => x.GetOrderById(It.IsAny<string>())).Returns((string s) => MockOrderList.Where(x => x.OrderID == s).Single());

            //act
            var mockedDal = dalMock.Object;
            var mockedOrder = mockedDal.GetOrderById("Order-01");

            //assert
            Assert.AreEqual("Order-01", mockedOrder.OrderID);
        }

        [Test]
        public void Update_Status_By_OrderID_Should_Return_One_Order()
        {
            //arrange
            var dalMock = new Mock<IOrderDAL>();
            dalMock.Setup(x => x.UpdateOrderStatus(It.IsAny<string>(), It.IsAny<string>())).Returns((string s, string t) => MockOrderList.Where(x => x.OrderID == s).Single());

            //act
            var mockedDal = dalMock.Object;
            var mockedOrder = mockedDal.UpdateOrderStatus("Order-01", "Shipped");

            //assert
            Assert.IsNotNull(mockedOrder);
            Assert.AreEqual("Shipped", mockedOrder.Status);
        }

        [TearDown]
        public void TestCleanUp()
        {
            MockOrderList = null;
            Order = null;
        }
    }
}