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
                context.Add(department);
                context.SaveChanges();
                return department;
            }
        }
    }
}
