using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ITripBLL
    {
        List<TripDTO> getAll();

        TripDTO GetById(int code);

        int add(TripDTO newTrip);

        bool Delete(int code);

        bool update(TripDTO newT);

        List<OrderPlaceDTO> GetInvitesToTrip(int code);

    }
}
