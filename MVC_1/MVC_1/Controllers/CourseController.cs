using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_1.Controllers
{
    public class CourseController : Controller
    {
        public static List<Course> courses = new List<Course>()
        {
            new Course(){Code="csh",Name="C Sharp"}
        };
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        // return the json file : select
        public JsonResult AllCourses()
        {
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // insert new course
        public JsonResult AddCourse(string code , string name)
        {
            courses.Add(new Course()
            {
                Code = code,
                Name = name
            });
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCourse(string code , string newName)
        {
            foreach(var course in courses)
            {
                if(course.Code == code)
                {
                    course.Name = newName;
                    break;
                }
            }

            return Json(courses, JsonRequestBehavior.AllowGet);
        } 

        // select by course code
        public string GetCourse(string code)
        {
            string str = "";
            foreach(var course in courses)
            {
                if(course.Code == code)
                {
                    str = String.Format("Course Code : {0} , Course Name : {1}", course.Code, course.Name);
                    
                    break;
                }
            }
            return str;
        }
        public JsonResult DeleteCourse(string code)
        {
            for(int i=0; i<courses.Count; i++)
            {
                if (courses[i].Code == code)
                {
                    courses.RemoveAt(i);
                    break;
                }
            }
            //foreach(var course in courses)
            //{
            //    if (course.Code==code)
            //    {
            //        courses.Remove(course);
            //        break;
            //    }
            //}
                

            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}