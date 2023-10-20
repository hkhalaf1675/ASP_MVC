using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_MVC.Models;

namespace University_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult AllStudents()
        {
            return View(StudentBL.students);
        }
        #region Add New Student 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, int age, string gender, string image)
        {
            StudentBL.AddNewStudent(name, age, gender, image);
            TempData["student"] = StudentBL.students.LastOrDefault();
            return RedirectToAction("AllStudents");
        }
        #endregion

        #region Delete Student
        public ActionResult Delete(int id)
        {
            var student = StudentBL.students.FirstOrDefault(S => S.ID == id);

            TempData["DelStudent"] = student.Name;

            StudentBL.DeleteStudent(student);

            return RedirectToAction("AllStudents");
        } 
        #endregion

        #region Update Student Info
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.student = StudentBL.students.FirstOrDefault(S => S.ID == id);
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, string name, string image, int age, string gender)
        {
            StudentBL.UpdateStudent(StudentBL.students.FirstOrDefault(S => S.ID == id), name, age, gender, image);

            TempData["UpdStudent"] = id;
            return RedirectToAction("AllStudents");
        } 
        #endregion
    }
}