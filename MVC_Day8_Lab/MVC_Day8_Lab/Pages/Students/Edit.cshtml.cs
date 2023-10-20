using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Day8_Lab.Models;

namespace MVC_Day8_Lab.Pages.Students
{
    public class EditModel : PageModel
    {
        SchoolDbContext context;
        [BindProperty]
        public Student Student { get; set; }
        public EditModel(SchoolDbContext _context)
        {
            context = _context;

        }
        public IActionResult OnGet(int? id)
        {
            Student = context.Students.FirstOrDefault(S => S.Id == id);
            if (Student == null)
            {
                return BadRequest();
            }
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Entry(Student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    
                    context.SaveChanges();
                    TempData["UpdatedStudent"] = Student.Fname;
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
