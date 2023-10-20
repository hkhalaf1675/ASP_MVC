using IntensiveCodeCamp.Models.Configrations;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.Contexts
{
    // install EntityFramework
    // inherit from Dbcontext
    public class IntensiveDbContext:DbContext
    {
        // connection string name on the Ctor chaining
        public IntensiveDbContext():base("name=IntensiveDBConnection")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // apply configration on intake model 
            //modelBuilder.Configurations.Add(new IntakeConfigrations());

            //modelBuilder.Entity<Track>()
            //    .Property(T => T.Name)
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Course>()
            //    .Property(C => C.Name)
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50)
            //    .HasColumnAnnotation("Display", "Course Name");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Intake> Intakes { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}