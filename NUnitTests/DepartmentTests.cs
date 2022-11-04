namespace NUnitTests
{
    public class DepartmentTests
    {
        private List<Department> MockDepartmentList;
        private Department Department;

        [SetUp]
        public void Setup()
        {
            MockDepartmentList = new List<Department>();
            Department department = new Department();
            department.DepartmentID = "Department-01";
            department.Name = "Wiley and Co";

            MockDepartmentList.Add(department);
        }

        [Test]
        public void Create_Department_Should_Return_One_Department()
        {
            //arrange
            var department = MockDepartmentList.First();
            var dalMock = new Mock<IDepartmentDAL>();
            dalMock.Setup(x => x.CreateDepartment(It.IsAny<Department>())).Returns(department);

            //act
            var mockedDal = dalMock.Object;
            var mockedDepartment = mockedDal.CreateDepartment(department);

            //assert
            Assert.IsNotNull(mockedDepartment);
            Assert.IsInstanceOf(typeof(Department), mockedDepartment);
            Assert.That(mockedDepartment.DepartmentID, Is.EqualTo(department.DepartmentID));
        }

        [Test]
        public void Get_Departments_Should_Return_All_Departments()
        {
            //arrange
            var dalMock = new Mock<IDepartmentDAL>();
            dalMock.Setup(x => x.GetDepartments());

            //act
            var mockedDal = dalMock.Object;
            var mockedDepartment = mockedDal.GetDepartments();

            //assert
            Assert.IsNotNull(mockedDepartment);
        }

        [TearDown]
        public void TestCleanUp()
        {
            MockDepartmentList = null;
            Department = null;
        }
    }
}
