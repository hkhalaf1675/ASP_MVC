using IntensiveCodeCamp.Models.Contexts;
using IntensiveCodeCamp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IntensiveCodeCamp.Models.BL
{
    public static class TrackBL
    {
        static IntensiveDbContext context;
        static TrackBL()
        {
            context = new IntensiveDbContext();
        }
        public static List<Track> AllTracks()
        {
            try
            {
                return context.Tracks.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Track SelectByID(int? id)
        {
            try
            {
                return context.Tracks.FirstOrDefault(t => t.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Track> SearchByName(string name)
        {
            try
            {
                return context.Tracks.Where(T => T.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Add(Track track)
        {
            if (SelectByID(track?.ID) == null)
            {
                try
                {
                    context.Tracks.Add(track);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool Update(Track track)
        {
            Track oldTrack = SelectByID(track?.ID);
            if (oldTrack == null)
            {
                //Add(track);
                return true;
            }
            else
            {
                try
                {
                    //context.Entry(track).State = System.Data.Entity.EntityState.Modified;
                    oldTrack.Name = track.Name;
                    oldTrack.IntakeRound = track.IntakeRound;

                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Delete(Track track)
        {
            try
            {
                context.Tracks.Remove(track);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}