using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    [NotMapped]
    public static class CourseBL
    {
        static DataContext context;
        static CourseBL()
        {
            context = new DataContext();
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
        public static List<Course> AllCourses()
        {
            return context.Courses.ToList();
        }
        public static Course SelectByCode(string code)
        {
            return context.Courses.FirstOrDefault(C => C.Code == code);
        }
        public static List<Course> SelectByName(string name)
        {
            return context.Courses.Where(C => C.Name == name).ToList();
        }
        public static bool AddCourse(Course course)
        {
            if (context.Courses.FirstOrDefault(C => C.Code == course.Code) == null)
            {
                try
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }
        public static bool DeleteCourse(string code)
        {
            var course = context.Courses.FirstOrDefault(C => C.Code == code);
            if (course != null)
            {
                try
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool UpdateCourse(Course course)
        {
            var crs = context.Courses.FirstOrDefault(C => C.Code == course.Code);
            if (crs != null)
            {
                try
                {
                    crs.Name = course.Name;
                    crs.Duration = course.Duration;
                    crs.Description = course.Description;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static List<Department> AllDepartments()
        {
            return context.Departments.ToList();
        }
        public static List<Instructor> AllInstructors()
        {
            return context.Instructors.ToList();
        }

    }
}