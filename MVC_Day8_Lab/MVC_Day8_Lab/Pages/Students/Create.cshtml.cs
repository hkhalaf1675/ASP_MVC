using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Day8_Lab.Models;

namespace MVC_Day8_Lab.Pages.Students
{
    public class CreateModel : PageModel
    {
        SchoolDbContext context;
        [BindProperty]
        public Student Student { get; set; }
        public CreateModel(SchoolDbContext _context)
        {
            context = _context;
            Student = new Student();

        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //context.Entry(Student).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    context.Students.Add(Student);
                    context.SaveChanges();
                    TempData["AddedStudent"] = Student.Fname;
                    return RedirectToPage("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Database Error", "There is an error on database");
                }
            }
            return Page();
        }
    }
}
