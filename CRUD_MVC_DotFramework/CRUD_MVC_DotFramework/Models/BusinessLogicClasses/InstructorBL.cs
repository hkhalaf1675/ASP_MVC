using CRUD_MVC_DotFramework.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.BusinessLogicClasses
{
    public static class InstructorBL
    {
        static UniversityDBContext context;
        static InstructorBL()
        {
            context = new UniversityDBContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UniversityDBContext>());
        }
        public static List<Instructor> AllInstructors()
        {
            return context.Instructors.ToList();
        }
        public static Instructor SelectInstructorBySSN(int ssn)
        {
            return context.Instructors.FirstOrDefault(I => I.SSN == ssn);
        }
        public static IEnumerable<Instructor> SearchInstructorByName(string name)
        {
            return context.Instructors.Where(I => I.FullName == name).ToList();
        }
        public static bool AddNewInstructor(Instructor instructor)
        {
            if (SelectInstructorBySSN(instructor.SSN) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.Instructors.Add(instructor);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public static bool DeleteInstructor(Instructor instructor)
        {
            if (SelectInstructorBySSN(instructor.SSN) != null)
            {
                try
                {
                    context.Instructors.Remove(instructor);
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
        public static bool UpdateInstructor(int ssn, string name,decimal salary, int dept)
        {
            Instructor instructor = SelectInstructorBySSN(ssn);
            if (instructor != null)
            {
                try
                {
                    instructor.FullName = name;
                    instructor.Salary = salary;
                    instructor.DepartmentId = dept;
                    context.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }
    }
}