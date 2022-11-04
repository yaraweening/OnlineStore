using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IDepartmentService
    {
        Department CreateDepartment(Department department);
        IActionResult GetDepartments();
    }
}
