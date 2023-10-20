using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Day8_Lab.Models;

namespace MVC_Day8_Lab.Pages.Students
{
    public class IndexModel : PageModel
    {
        SchoolDbContext context;
        public List<Student> Students{ get; set; }
        public IndexModel(SchoolDbContext _context)
        {
            Students = new List<Student>();
            context = _context;
        }
        public void OnGet()
        {
            Students = context.Students.ToList();
            
        }

        public IActionResult OnPostDelete(int? id)
        {
            Student std = context.Students.FirstOrDefault(S => S.Id == id);
            if(std != null)
            {
                try
                {
                    context.Students.Remove(std);
                    context.SaveChanges();
                    TempData["DeletedStudent"] = std.Fname;
                    return RedirectToPage("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorDatabase"] = ex.Message;
                }
            }
            return BadRequest();
        }
    }
}
