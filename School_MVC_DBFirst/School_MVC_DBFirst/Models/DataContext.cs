using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School_MVC_DBFirst.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("SchoolDB")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCoursesView>().ToView("ViewNameOnDatabase").HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCoursesView> StudentCoursesViews { get; set; }
    }
}