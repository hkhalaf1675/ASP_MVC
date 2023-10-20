using School_MVC_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace School_MVC_DBFirst.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentBL.AllStudents());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["PerferCourses"] = new SelectList(CourseBL.AllCourses(),"Code","Name");
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                if (StudentBL.AddStudent(student))
                {
                    TempData["studentName"] = student.FName;
                    return RedirectToAction("Index");
                }
            }
            ViewData["PerferCourses"] = new SelectList(CourseBL.AllCourses(), "Code", "Name");
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            if (StudentBL.SelectByID(id) != null)
            {
                StudentBL.DeleteStudent(id);
                TempData["studentID"] = id;
                return RedirectToAction("Index");

                //return View(StudentBL.SelectByID(id));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "There is No Student With that ID");
            }

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewData["PerferCourses"] = new SelectList(CourseBL.AllCourses(), "Code", "Name");
            if (StudentBL.SelectByID(id) != null)
                return View(StudentBL.SelectByID(id));
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound,"There is No Student With that ID");
            }
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                if (StudentBL.UpdateStudent(student))
                {
                    TempData["studentIDUpdate"] = student.Id;
                    return RedirectToAction("Index");
                }
            }
            ViewData["PerferCourses"] = new SelectList(CourseBL.AllCourses(), "Code", "Name");
            return View(student);
        }
        
    }
}