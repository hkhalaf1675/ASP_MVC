using Microsoft.AspNetCore.Mvc;
using MVC_Day7_Lab.Models;
using System.Linq.Expressions;

namespace MVC_Day7_Lab.Controllers
{
    public class StudentController : Controller
    {
        SchoolDbContext context;
        public StudentController(SchoolDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View(context.Students.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            var Std = context.Students.FirstOrDefault(S => S.Id == id);
            if(Std != null)
            {
                return View(Std);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    TempData["updateStud"] = std.Fname;
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        public IActionResult Delete(int? id)
        {
            var std = context.Students.FirstOrDefault(s => s.Id == id);
            if(std != null)
            {
                try
                {
                    context.Students.Remove(std);
                    context.SaveChanges();
                    TempData["DeletedStudent"] = std.Fname;
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}
