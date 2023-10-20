using School_MVC_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_MVC_DBFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataContext context = new DataContext();
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
            context.Departments.Add(new Department()
            {
                ID = 1,
                Name = "Dept01",
            });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}