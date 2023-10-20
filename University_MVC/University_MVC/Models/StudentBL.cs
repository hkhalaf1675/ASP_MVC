using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace University_MVC.Models
{
    public static class StudentBL
    {
        public static List<Student> students = new List<Student>();
        static int count = 0;
        static StudentBL()
        {
            students.Add(new Student()
            {
                ID = ++count,
                Name = "Hassan Tawfik",
                Age = 25,
                Gender = "male",
                Image = "Male.png"
            });
        }
        public static void AddNewStudent(string name,int age,string gender,string image)
        {
            students.Add(new Student()
            {
                ID= ++count,
                Name = name,
                Age = age,
                Gender = gender,
                Image = image
            });
        }
        public static void DeleteStudent(Student std)
        {
            students.Remove(std);
        }
        public static void UpdateStudent(Student std,string name,int age,string gender,string image)
        {
            std.Name = name;
            std.Age = age;
            std.Gender = gender;
            std.Image = image;
        }
    }
}