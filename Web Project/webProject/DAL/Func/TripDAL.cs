using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class TripDAL : ITripDAL
    {
        TravelContext db;

        public TripDAL(TravelContext tc)
        {
            db = tc;
        }

        public List<Trip> getAll()
        {
            /*to check Include(x => x.OrederPlaces*/
            return db.Trips.Include(x => x.OrederPlaces).Include(y => y.CodeTypeNavigation).ToList();
        }

        /**/
        public Trip GetById(int code)
        {
            return db.Trips.Include(x=>x.OrederPlaces).Include(y=>y.CodeTypeNavigation).First(z=>z.CodeTrip==code);
        }

        public int add(Trip newTrip)
        {
            db.Trips.Add(newTrip);
            db.SaveChanges();
            return newTrip.CodeTrip;
        }

        public bool Delete(int code)
        {
            Trip? obj = db.Trips.FirstOrDefault(x => x.CodeTrip == code);
            if (obj != null)
            {
                db.Trips.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /*לבדוק*/
        public bool update(Trip newT)
        {
            Trip? t = db.Trips.FirstOrDefault(x => x.CodeTrip == newT.CodeTrip);
            if (t != null)
            {
                t = newT;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}


    
    

