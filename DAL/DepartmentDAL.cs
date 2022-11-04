using DAL.Context;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class DepartmentDAL : IDepartmentDAL
    {
        public Department CreateDepartment(Department department)
        {
            using (var context = new OnlineStoreContext())
            {
                if (DepartmentExists(department.DepartmentID))
                {
                    throw new Exception("This department id already exists");
                }

                context.Add(department);
                context.SaveChanges();
                return department;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Departments.ToList();
            }

            return null;
        }

        private static bool DepartmentExists(string departmentID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Departments.Any(e => e.DepartmentID == departmentID);
            }
        }
    }
}
