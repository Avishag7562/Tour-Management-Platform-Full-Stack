using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Func
{
    public class UserDAL : IUserDAL
    {
        TravelContext db;

        public UserDAL(TravelContext tc)
        {
            db = tc;
        }

     

        public List<User> getAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(x => x.CodeUser == id);
        }

        public User GetByMailAndPassword(string email, string password)
        {
            return db.Users.FirstOrDefault(x => x.Email == email && x.EntryPassword == password);
        }

        public int add(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
            return newUser.CodeUser;
        }

        public bool Delete(int code)
        {
            User? obj = db.Users.FirstOrDefault(x => x.CodeUser == code);
            if (obj != null)
            {
                db.Users.Remove(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /*לבדוק*/
        public bool update(User newU)
        {
            User? user = db.Users.FirstOrDefault(x => x.CodeUser == newU.CodeUser);
            if (user != null)
            {
                user = newU;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

