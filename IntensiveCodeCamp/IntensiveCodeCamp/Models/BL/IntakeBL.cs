using IntensiveCodeCamp.Models.Contexts;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntensiveCodeCamp.Models.BL
{
    public static class IntakeBL
    {
        static IntensiveDbContext context;

        static IntakeBL()
        {
            context = new IntensiveDbContext();
        }
        public static List<Intake> AllIntakes()
        {
            try
            {
                return context.Intakes.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static Intake SelectByRound(int? round)
        {
            try
            {
                return context.Intakes.FirstOrDefault(x => x.Round == round);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Intake> SearchByName(string name)
        {
            try
            {
                return context.Intakes.Where(I => I.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Add(Intake intake)
        {
            if(SelectByRound(intake?.Round) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.Intakes.Add(intake);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Update(Intake intake)
        {
            Intake oldIntake = SelectByRound(intake?.Round);
            if (oldIntake == null)
                return false;
            else
            {
                try
                {
                    //context.Entry(intake).State = EntityState.Modified;
                    oldIntake.Name = intake.Name;
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Delete(Intake intake)
        {
            try
            {
                context.Intakes.Remove(intake);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}