using MVC_Day2_CRUDWithBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Day2_CRUDWithBootstrap.Controllers
{
    public class InstructorController : Controller
    {
        static List<Instructor> instructors = new List<Instructor>()
        {
            new Instructor()
            {
                ID = 1,
                Name = "Inst01",
                Department = "Dept01"
            },
            new Instructor()
            {
                ID= 2,
                Name = "Inst02",
                Department = "Dept01"
            }
        };
        // GET: Instructor
        public ActionResult Index()
        {
            ViewData["instructors"] = instructors;
            return View();
        }
        public ActionResult AddInstructor()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Create(int id , string name , string department)
        {
            bool f = false;
            foreach(var item in  instructors)
            {
                if (item.ID == id)
                {
                    f = true;
                    break;
                }
            }
            if(!f)
            {
                instructors.Add(new Instructor()
                {
                    ID = id,
                    Name = name,
                    Department = department
                });
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, $"ID {id} Already Exists");
        }

        public ActionResult DeleteInst(int id)
        {
            foreach(var item in instructors)
            {
                if (item.ID == id)
                {
                    instructors.Remove(item);
                    break;
                }
            }    
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInst(int id)
        {
            bool f = false;
            Instructor inst = new Instructor();
            foreach(var item in instructors)
            {
                if (item.ID == id)
                {
                    inst = item;
                    f = true;
                    break;
                }
            }
            if (f)
            {
                ViewData["inst"] = inst;
                return View();
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, $"ID {id} Already Exists");
        }
        [HttpPost]
        public ActionResult Update(int id, string name, string department)
        {
            foreach(var item in instructors)
            {
                if(item.ID == id)
                {
                    item.Name = name;
                    item.Department = department;
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}