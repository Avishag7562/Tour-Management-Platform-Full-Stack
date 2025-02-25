using DAL.Func;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserDAL
    {
        List<User> getAll();

        User GetById(int id);

        User GetByMailAndPassword(string email, string password);

        int add(User newUser);

        bool Delete(int id);

        bool update(User newU);

        int add(UserDAL userDAL);
    }
}
