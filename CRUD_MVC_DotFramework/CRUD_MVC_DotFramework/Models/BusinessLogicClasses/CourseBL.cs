using CRUD_MVC_DotFramework.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.BusinessLogicClasses
{
    public static class CourseBL
    {
        static UniversityDBContext context;
        static CourseBL()
        {
            context = new UniversityDBContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UniversityDBContext>());
        }
        public static List<Course> AllCourses()
        {
            return context.Courses.ToList();
        }
        public static Course SelectCourseByID(int id)
        {
            return context.Courses.FirstOrDefault(C => C.CourseID == id);
        }
        public static IEnumerable<Course> SearchCourseByName(string name)
        {
            return context.Courses.Where(C => C.CourseName == name).ToList();
        }
        public static bool AddNewCourse(Course course)
        {
            if (SelectCourseByID(course.CourseID) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public static bool DeleteCourse(Course course)
        {
            if (SelectCourseByID(course.CourseID) != null)
            {
                try
                {
                    context.Courses.Remove(course);
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
        public static bool UpdateCourse(int id, string name, short duration,int dept)
        {
            Course course = SelectCourseByID(id);
            if (course != null)
            {
                try
                {
                    course.CourseName = name;
                    course.CourseDuration = duration;
                    course.DepartmentId = dept;
                    context.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }
    }
}