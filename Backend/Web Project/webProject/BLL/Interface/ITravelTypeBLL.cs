using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ITravelTypeBLL
    {
        List<TravelTypeDTO> getAll();

        TravelTypeDTO GetById(int code);

        int add(TravelTypeDTO newType);

        bool Delete(int code);
    }
}
