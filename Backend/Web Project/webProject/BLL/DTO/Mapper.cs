using AutoMapper;
using DAL.Func;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<OrderPlaceDAL, OrderPlaceDTO>();
            CreateMap<TravelTypeDAL, TravelTypeDTO>();
            CreateMap<TripDAL, TripDTO>();
            CreateMap<UserDAL, UserDTO>();


            CreateMap<OrderPlaceDTO, OrderPlaceDAL>();
            CreateMap<TravelTypeDTO, TravelTypeDAL>();
            CreateMap<TripDTO, TripDAL>();
            CreateMap<UserDTO, UserDAL>();




        }
    }
}

