using Day9_Lab_Identity.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day9_Lab_Identity.Models.Contexts
{
    public class ShopDbContext:IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
