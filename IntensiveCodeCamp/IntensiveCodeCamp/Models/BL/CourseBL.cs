using IntensiveCodeCamp.Models.Contexts;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.BL
{
    public static class CourseBL
    {
        static IntensiveDbContext context;
        static CourseBL()
        {
            context = new IntensiveDbContext();
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IntensiveDbContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<IntensiveDbContext, Migrations.Configuration>());
        }
        public static List<Course> AllCourses()
        {
            try
            {
                return context.Courses.Include(C => C.Track).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Course SelectByID(int? id)
        {
            try
            {
                return context.Courses.FirstOrDefault(C => C.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Course> SearchByName(string name)
        {
            try
            {
                return context.Courses.Where(C => C.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Add(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(Course course)
        {
            Course crs = SelectByID(course?.ID);
            if (crs == null)
                return false;
            else
            {
                try
                {
                    //context.Entry(course).State = System.Data.Entity.EntityState.Modified;
                    crs.Name = course.Name;
                    crs.Description = course.Description;
                    crs.MaxDgree = course.MaxDgree;
                    crs.MinDgree = course.MinDgree;
                    crs.TrackID = course.TrackID;
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Delete(Course course)
        {
            try
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Course> SearchByTrackID(int? id)
        {
            try
            {
                return context.Courses.Where(C => C.TrackID == id).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}