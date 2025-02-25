using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IUserBLL
    {
        List<UserDTO> getAll();

        UserDTO GetByMailAndPassword(string email, string password);

        List<TripDTO> getAllTrips(int code);

        int add(UserDTO newUser);

        bool update(UserDTO newU);

        bool Delete(int id);

    }
}
