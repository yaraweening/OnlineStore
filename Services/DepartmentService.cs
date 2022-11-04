using DAL.Interfaces;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDAL _departmentDAL;

        public DepartmentService(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        public Department CreateDepartment(Department department)
        {
            department = new Department()
            {
                DepartmentID = department.DepartmentID,
                Name = department.Name
            };

            department = _departmentDAL.CreateDepartment(department);

            return department;
        }
    }
}
