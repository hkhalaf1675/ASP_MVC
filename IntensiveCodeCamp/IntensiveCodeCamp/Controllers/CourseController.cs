using IntensiveCodeCamp.Models.BL;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntensiveCodeCamp.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View(CourseBL.AllCourses());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["TrackID"] = new SelectList(TrackBL.AllTracks(), "ID", "Name");
            return View(new Models.Entities.Course());
        }

        [HttpPost]
        public ActionResult Create(Course cousre)
        {
            if (ModelState.IsValid)
            {
                if(CourseBL.Add(cousre))
                {
                    TempData["AddedCourse"] = cousre.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("All", "There is Error on Adding that Course");
                }
            }
            ViewData["TrackID"] = new SelectList(TrackBL.AllTracks(), "ID", "Name");
            return View(cousre);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Course course = CourseBL.SelectByID(id);
            if (course == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                ViewData["TrackID"] = new SelectList(TrackBL.AllTracks(), "ID", "Name", course.TrackID);
                return View(course);
            }
        }
        [HttpPost]
        public ActionResult Update(Course cousre)
        {
            if (ModelState.IsValid)
            {
                if (CourseBL.Update(cousre))
                {
                    TempData["UpdatedCourse"] = cousre.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("All", "There is Error on Updating that Course");
                }
            }
            ViewData["TrackID"] = new SelectList(TrackBL.AllTracks(), "ID", "Name",cousre.TrackID);
            return View(cousre);
        }
        public ActionResult Delete(int? id)
        {
            Course crs = CourseBL.SelectByID(id);
            if (crs == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            else
            {
                if (CourseBL.Delete(crs))
                {
                    TempData["DeletedCourse"] = crs.Name;
                    return RedirectToAction("Index");
                }
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}