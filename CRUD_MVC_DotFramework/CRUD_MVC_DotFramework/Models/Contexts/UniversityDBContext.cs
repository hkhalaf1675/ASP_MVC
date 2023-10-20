using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_MVC_DotFramework.Models.Contexts
{
    public class UniversityDBContext:DbContext
    {
        public UniversityDBContext():base("name = UniversityDBMVCConnection")
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().Property(D => D.DeptName).IsOptional();
        }
    }
}