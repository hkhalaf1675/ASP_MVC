using CRUD_MVC_DotFramework.Models;
using CRUD_MVC_DotFramework.Models.BusinessLogicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_DotFramework.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View(DepartmentBL.AllDepartments());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["Instructors"] = new SelectList(InstructorBL.AllInstructors(),"SSN","FullName");
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                if (DepartmentBL.AddNewDepartment(department))
                {
                    return RedirectToAction("Index");
                }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ViewData["Instructors"] = new SelectList(InstructorBL.AllInstructors(), "SSN", "FullName");
            return View(department);
        }
    }
}