using CRUD_MVC_DotFramework.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.BusinessLogicClasses
{
    public static class StudentBL
    {
        static UniversityDBContext context;
        static StudentBL()
        {
            context = new UniversityDBContext();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UniversityDBContext>());
        }
        public static List<Student> AllStudents()
        {
            return context.Students.ToList();
        }
        public static Student SelectStudentBySSN(int ssn)
        {
            return context.Students.FirstOrDefault(S => S.SSN == ssn);
        }
        public static IEnumerable<Student> SearchStudentByName(string name)
        {
            return context.Students.Where(S => S.FullName == name).ToList();
        }
        public static bool AddNewStudent(Student student)
        {
            if (SelectStudentBySSN(student.SSN) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public static bool DeleteStudent(Student student)
        {
            if (SelectStudentBySSN(student.SSN) != null)
            {
                try
                {
                    context.Students.Remove(student);
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
        public static bool UpdateStudent(Student std)
        {
            Student student = SelectStudentBySSN(std.SSN);
            if (student != null)
            {
                try
                {
                    student.FullName = std.FullName;
                    student.Age = std.Age;
                    student.Level = std.Level;
                    context.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }
    }
}