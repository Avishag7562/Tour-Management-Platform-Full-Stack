using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL.Func;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapper = BLL.DTO.Mapper;

namespace BLL.Func
{
    public class UserBLL : IUserBLL
    {
        IUserDAL iuserDal;
        ITripDAL itripDal;
        IOrederPlaceDAL iopDal;
        IMapper imapper;

        public UserBLL(IUserDAL u, IOrederPlaceDAL op, ITripDAL t)
        {
            iuserDal = u;
            iopDal = op;
            itripDal = t;   
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });
            imapper = config.CreateMapper();
        }

        public int add(UserDTO newUser)
        {
            if (newUser.FirstName != null && Regex.IsMatch(newUser.FirstName, @"^[\u0590-\u05FF]+$") &&
                newUser.LastName != null && Regex.IsMatch(newUser.LastName, @"^[\u0590-\u05FF]+$") &&
                newUser.Phone.Length == 10 && int.TryParse(newUser.Phone, out _) &&
                newUser.Email != null && Regex.IsMatch(newUser.Email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                return iuserDal.add(imapper.Map<UserDTO, UserDAL>(newUser));
            }
            return -1;
        }

        public bool Delete(int id)
        {
            if (iopDal.getAll().FirstOrDefault(x => x.CodeUser == id) == null)
                return iuserDal.Delete(id);
            return false;
        }

        public List<UserDTO> getAll()
        {
            return imapper.Map<List<User>, List<UserDTO>>(iuserDal.getAll());
        }


        public UserDTO GetByMailAndPassword(string email, string password)
        {
            return imapper.Map<User, UserDTO>(iuserDal.GetByMailAndPassword(email, password));
        }


        public bool update(UserDTO newU)
        {
            if (newU.FirstName != null && Regex.IsMatch(newU.FirstName, @"^[\u0590-\u05FF]+$") &&
                newU.LastName != null && Regex.IsMatch(newU.LastName, @"^[\u0590-\u05FF]+$") &&
                newU.Phone.Length == 10 && int.TryParse(newU.Phone, out _) &&
                newU.Email != null && Regex.IsMatch(newU.Email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                return iuserDal.update(imapper.Map<UserDTO, User>(newU));
            }
            return false;
        }


        public List<TripDTO> getAllTrips(int code)
        {
            List<OrederPlace> lstSearch = iopDal.getAll().FindAll(x => x.CodeUser == code);
                if (lstSearch != null)
                {
                    List<TripDTO> userTrips = lstSearch.
                    Select(x => imapper.Map<Trip, TripDTO>(itripDal.GetById((int)x.CodeTrip!))).ToList();
                    return userTrips;
                }
            return null;
        }
    }
}
