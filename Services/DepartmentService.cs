using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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

        public IActionResult GetDepartments()
        {
            return (new ActionResult<IEnumerable<Department>>(_departmentDAL.GetDepartments()) as IConvertToActionResult).Convert();
        }
    }
}
