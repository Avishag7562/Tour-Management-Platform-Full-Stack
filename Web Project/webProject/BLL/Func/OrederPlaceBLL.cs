using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL.Func;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mapper = BLL.DTO.Mapper;

namespace BLL.Func
{
    public class OrederPlaceBLL : IOrederPlaceBLL

    {
        IOrederPlaceDAL IopDal;
        ITripDAL itripdal;
        IMapper imapper;

        public OrederPlaceBLL(IOrederPlaceDAL iDal , ITripDAL t)
        {
            IopDal = iDal;
            itripdal = t;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });
            imapper = config.CreateMapper();
        }


        public List<OrderPlaceDTO> getAllToTrip(int code)
        {
            return imapper.Map<List<OrederPlace>, List<OrderPlaceDTO>>(IopDal.getAll().Where(x => x.CodeTrip == code).ToList());
        }


        public int add(OrderPlaceDTO newOrder)
        {
            Trip x= itripdal.GetById(newOrder.CodeTrip);

            if (newOrder.DateOrder < DateTime.Now &&
                          itripdal.GetById(newOrder.CodeTrip).AvailablePlaces > 0)
            {
                IopDal.GetById(newOrder.CodeOrder).DateOrder = DateTime.Now;
                itripdal.GetById(newOrder.CodeTrip).AvailablePlaces -= newOrder.NumPlaces;
                return IopDal.add(imapper.Map<OrderPlaceDTO, OrederPlace>(newOrder));
            }
            return -1;
        }

        public bool Delete(OrderPlaceDTO o)
        {
            if ( o.Date > DateTime.Now)
                return false;
            else
            {
                itripdal.GetById(o.CodeTrip).AvailablePlaces += 1;
                return IopDal.Delete(o.CodeOrder);
            }
        }


      

     
    }
}