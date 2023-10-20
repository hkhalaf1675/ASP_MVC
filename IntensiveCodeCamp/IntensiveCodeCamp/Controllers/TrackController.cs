using IntensiveCodeCamp.Models.BL;
using IntensiveCodeCamp.Models.Configrations;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntensiveCodeCamp.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult Index()
        {
            return View(TrackBL.AllTracks());
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            ViewData["IntakeRound"] = new SelectList(IntakeBL.AllIntakes(), "Round", "Name");
            return View(new Models.Entities.Track());
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                if (TrackBL.Add(track))
                {
                    TempData["AddedTrack"] = track.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("All", "There is Error on Adding that Track");
                }
            }
            ViewData["IntakeRound"] = new SelectList(IntakeBL.AllIntakes(), "Round", "Name");
            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Update(int? id)
        {
            Track track = TrackBL.SelectByID(id);
            if (track == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                ViewData["IntakeRound"] = new SelectList(IntakeBL.AllIntakes(), "Round", "Name",track.IntakeRound);
                return View(track);
            }
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Update(Track track)
        {
            if (ModelState.IsValid)
            {
                if (TrackBL.Update(track))
                {
                    TempData["UpdatedTrack"] = track.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("All", "There is Error on Updating that Track");
                }
            }
            ViewData["IntakeRound"] = new SelectList(IntakeBL.AllIntakes(), "Round", "Name", track.IntakeRound);
            return View(track);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            Track track = TrackBL.SelectByID(id);
            if (track == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            else
            {
                if (TrackBL.Delete(track))
                {
                    TempData["DeletedTrack"] = track.Name;
                    return RedirectToAction("Index");
                }
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }

        public ActionResult AllTrackCourses(int? id)
        {
            Track track = TrackBL.SelectByID(id);
            if(track == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(track);
        }

        public ActionResult Details(int? id)
        {
            Track track = TrackBL.SelectByID(id);
            if (track == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                return PartialView(track);
            }
        }
        public ActionResult TrackCourses(int? id)
        {
            if (TrackBL.SelectByID(id) == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                return PartialView(CourseBL.SearchByTrackID(id));
            }
        }
    }
}
