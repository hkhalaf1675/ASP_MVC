using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntensiveCodeCamp.Models.Contexts;
using IntensiveCodeCamp.Models.Entities;
using IntensiveCodeCamp.Models.BL;

namespace IntensiveCodeCamp.Controllers
{
    public class IntakeController : Controller
    {

        // GET: Intake
        public ActionResult Index()
        {
            return View(IntakeBL.AllIntakes());
        }

        // GET: Intake/Create
        public ActionResult Create()
        {
            return View(new Intake());
        }

        // POST: Intake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Intake intake)
        {
            if (ModelState.IsValid)
            {
                if (IntakeBL.Add(intake))
                {
                    TempData["AddedIntake"] = intake.Round;
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("All", "There is Error at adding that Inatke");
            }

            return View(intake);
        }

        // GET: Intake/Edit/5
        public ActionResult Edit(int? id)
        {
            Intake intake = IntakeBL.SelectByRound(id);
            if (intake == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                return View(intake);
            }
        }

        // POST: Intake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Intake intake)
        {
            if (ModelState.IsValid)
            {
                if (IntakeBL.Update(intake))
                {
                    TempData["UpdatedIntake"] = intake.Round;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("All", "There is Error on Updating that Intake");
                }
            }
            return View(intake);
        }

        // GET: Intake/Delete/5
        public ActionResult Delete(int? id)
        {
            Intake intake = IntakeBL.SelectByRound(id);
            if (intake == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            else
            {
                if (IntakeBL.Delete(intake))
                {
                    TempData["DeletedIntake"] = intake.Round;
                    return RedirectToAction("Index");
                }
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
