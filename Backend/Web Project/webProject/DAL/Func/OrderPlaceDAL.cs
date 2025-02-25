using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class OrderPlaceDAL : IOrederPlaceDAL
    {
        static TravelContext db = new TravelContext();

        public OrderPlaceDAL(TravelContext tc)
        {
            db = tc;
        }

    
        public List<OrederPlace> getAll()
        {
            return db.OrederPlaces.Include(x => x.CodeTripNavigation).Include(y => y.CodeUserNavigation).ToList();
        }

        /*******/
        public OrederPlace GetById(int code)
        {
            return db.OrederPlaces.FirstOrDefault(x => x.CodeOrder == code);
        }


        public int add(OrederPlace newOrder)
        {
            db.OrederPlaces.Add(newOrder);
            db.SaveChanges();
            return newOrder.CodeOrder;  
        }

        public bool Delete(int code)
        {
            OrederPlace? obj = db.OrederPlaces.FirstOrDefault(x => x.CodeOrder == code);
            if (obj != null)
            {
                db.OrederPlaces.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
