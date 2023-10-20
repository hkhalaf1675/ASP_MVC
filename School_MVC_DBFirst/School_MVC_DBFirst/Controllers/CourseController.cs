using School_MVC_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace School_MVC_DBFirst.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View(CourseBL.AllCourses());
        }
        public ActionResult AllCourses()
        {
            return PartialView(CourseBL.AllCourses());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                if(CourseBL.AddCourse(course))
                {
                    RedirectToAction("Index");
                }
            }
            return View(course);
        }
        public ActionResult Delete(string id)
        {
            if (CourseBL.SelectByCode(id) != null)
            {
                CourseBL.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound, "There is No Course With that Code");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            if(CourseBL.SelectByCode(id) != null)
            {
                return View(CourseBL.SelectByCode(id));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "There is No Course With that Code");
            }
        }

        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseBL.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            else
            {
                return View(course);
            }
        }
    }
}