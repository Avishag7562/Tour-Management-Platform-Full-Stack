using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrederPlaceBLL
    {
        List<OrderPlaceDTO> getAllToTrip(int code);

        int add(OrderPlaceDTO newOrder);

        bool Delete(OrderPlaceDTO o);
    }
}
