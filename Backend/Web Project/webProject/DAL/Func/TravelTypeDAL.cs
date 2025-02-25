using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class TravelTypeDAL:ITravelTypeDAL
    {
        TravelContext db;

        public TravelTypeDAL(TravelContext tc)
        {
            db = tc;
        }

        public List<TravelType> getAll()
        {
            return db.TravelTypes.ToList();
        }

        public TravelType GetById(int code)
        {
            return db.TravelTypes.FirstOrDefault(x => x.CodeType == code);
        }

        public int add(TravelType newType)
        {
            db.TravelTypes.Add(newType);
            db.SaveChanges();
            return newType.CodeType;
        }

        public bool Delete(int code)
        {
            TravelType? obj = db.TravelTypes.FirstOrDefault(x => x.CodeType == code);
            if (obj != null)
            {
                db.TravelTypes.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
