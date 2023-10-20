using School_MVC_DBFirst.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    [NotMapped]
    public static class Helper
    {
        static DataContext context;
        static Helper()
        {
            context = new DataContext();
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
        public static Department SelectDepartmentById(int id)
        {
            return context.Departments.FirstOrDefault(D => D.ID == id);
        }
        public static Instructor SelectInstructorById(int id)
        {
            return context.Instructors.FirstOrDefault(D => D.ID == id);
        }
        public static List<DepartmentInstructors> DepartmentInstructors()
        {
            List<DepartmentInstructors> instructors = new List<DepartmentInstructors>();
            foreach(var item in context.Departments.ToList())
            {
                DepartmentInstructors deptInstructors = new DepartmentInstructors();
                deptInstructors.Id = item.ID;
                deptInstructors.Name = item.Name;
                deptInstructors.Instructors = context.Instructors.Where(I => I.Department.ID == item.ID).ToList();
                instructors.Add(deptInstructors);
            }
            
            return instructors;
        }
    }
}