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
    public class TravelTypeBLL : ITravelTypeBLL
    {
        ITravelTypeDAL tDal;
        IMapper imapper;

        public TravelTypeBLL(TravelTypeDAL t)
        {
            tDal = t;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });
            imapper = config.CreateMapper();
        }

        public int add(TravelTypeDTO newType)
        {
            if (tDal.getAll().FirstOrDefault(x => x.CodeType == newType.CodeType) != null)
                return -1;
           return tDal.add(imapper.Map<TravelTypeDTO, TravelType>(newType));
        }

        public bool Delete(int code)
        {
            return tDal.Delete(code);
        }

        public List<TravelTypeDTO> getAll()
        {
            return imapper.Map<List<TravelType>, List<TravelTypeDTO>>(tDal.getAll());
        }

        public TravelTypeDTO GetById(int code)
        {
            throw new NotImplementedException();
        }
    }
}
