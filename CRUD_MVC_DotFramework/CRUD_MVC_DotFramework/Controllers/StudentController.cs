using CRUD_MVC_DotFramework.Models;
using CRUD_MVC_DotFramework.Models.BusinessLogicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_DotFramework.Controllers
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
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                if(StudentBL.AddNewStudent(student))
                {
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Student student = StudentBL.SelectStudentBySSN(id);
            if (student != null)
            {
                return View(student);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
        }
        [HttpPost]
        public ActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                if (StudentBL.UpdateStudent(student))
                {
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            return View(student);
        }
    }
}