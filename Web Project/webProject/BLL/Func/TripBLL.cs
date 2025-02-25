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
using System.Threading.Tasks;
using Mapper = BLL.DTO.Mapper;

namespace BLL.Func
{
    public class TripBLL : ITripBLL
    {
        ITripDAL itripDal;
        IOrederPlaceDAL iopdal;
        IMapper imapper;

        public TripBLL (ITripDAL t, IOrederPlaceDAL o)
        {
            itripDal = t;
            iopdal = o;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });
            imapper = config.CreateMapper();
        }

        public int add(TripDTO newTrip)
        {
            TimeSpan rang = (TimeSpan)(newTrip.DateTrip - DateTime.Now)!;
            if(newTrip.DateTrip > DateTime.Now && rang.TotalDays <= 90
                && newTrip.TripHours >= 3 && newTrip.TripHours <= 12  
                && newTrip.AvailablePlaces > 0 
                && newTrip.Price < 15000 && newTrip.Price > 0 )
            {
                itripDal.add(imapper.Map<TripDTO, Trip>(newTrip));
            }
            return -1;
         
        }

        public bool Delete(int code)
        {
            throw new NotImplementedException();
        }

        public List<TripDTO> getAll()
        {
            return imapper.Map<List<Trip>, List<TripDTO>>(itripDal.getAll());
        }

        public TripDTO GetById(int code)
        {
            return getAll().First(x => x.CodeTrip == code);
        }

        public List<OrderPlaceDTO> GetInvitesToTrip(int code)
        {
            return imapper.Map<List<OrederPlace>, List<OrderPlaceDTO>>(iopdal.getAll().Where(x => x.CodeTrip == code).ToList());
        }

        public bool update(TripDTO newT)
        {
            TimeSpan rang = (TimeSpan)(newT.DateTrip - DateTime.Now)!;
            if (newT.DateTrip > DateTime.Now && rang.TotalDays <= 90
                && newT.TripHours >= 3 && newT.TripHours <= 12
                && newT.DateTrip < DateTime.Now
                && newT.AvailablePlaces > 0
                && newT.Price < 15000 && newT.Price > 0)
            {
                return itripDal.update(imapper.Map<TripDTO, Trip>(newT));
            }
        }
    }
}
