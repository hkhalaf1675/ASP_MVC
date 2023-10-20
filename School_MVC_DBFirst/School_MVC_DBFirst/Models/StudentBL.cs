using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    [NotMapped]
    public static class StudentBL
    {
        static DataContext context;
        static StudentBL()
        {
            context = new DataContext();
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
        }


        public static List<Student> AllStudents()
        {
            return context.Students.ToList();
        }
        public static Student SelectByID(int id)
        {
            return context.Students.FirstOrDefault(S => S.Id == id);
        }
        public static List<Student> SelectByFName(string name)
        {
            return context.Students.Where(S => S.FName == name).ToList();
        }
        public static bool AddStudent(Student student)
        {
            if (context.Students.FirstOrDefault(S => S.Id == student.Id) == null)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public static bool DeleteStudent(int id)
        {
            var student = context.Students.FirstOrDefault(S => S.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool UpdateStudent(Student student)
        {
            var std = context.Students.FirstOrDefault(S => S.Id == student.Id);
            if (std != null)
            {
                std.FName = student.FName;
                std.LName = student.LName;
                std.BirthDate = student.BirthDate;
                std.Address = student.Address;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}