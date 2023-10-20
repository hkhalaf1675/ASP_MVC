using CRUD_MVC_DotFramework.Models.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_MVC_DotFramework.Models.BusinessLogicClasses
{
    public static class DepartmentBL
    {
        static UniversityDBContext context;
        static DepartmentBL()
        {
            context = new UniversityDBContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UniversityDBContext>());
        }
        public static List<Department> AllDepartments()
        {
            return context.Departments.ToList();
        }
        public static Department SelectDepartmentByID(int id)
        {
            return context.Departments.FirstOrDefault(D => D.DepartmentId == id);
        }
        public static IEnumerable<Department> SearchDepartmentByName(string name)
        {
            return context.Departments.Where(D => D.DeptName == name).ToList();
        }
        public static bool AddNewDepartment([Bind]Department dept)
        {
                try
                {
                    context.Departments.Add(dept);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
        }
        public static bool DeleteDepartment(Department dept)
        {
            if(SelectDepartmentByID(dept.DepartmentId) != null)
            {
                try
                {
                    context.Departments.Remove(dept);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool UpdateDepartment(int id,string name,int manager)
        {
            Department dept = SelectDepartmentByID(id);
            if ( dept != null)
            {
                try
                {
                    dept.DeptName = name;
                    dept.ManagerID = manager;
                    context.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }
    }
}