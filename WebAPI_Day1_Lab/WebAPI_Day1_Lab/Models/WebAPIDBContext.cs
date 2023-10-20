using Microsoft.EntityFrameworkCore;

namespace WebAPI_Day1_Lab.Models
{
    public class WebAPIDBContext:DbContext
    {
        public WebAPIDBContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
