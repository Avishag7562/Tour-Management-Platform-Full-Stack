using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITravelTypeDAL
    {
        List<TravelType> getAll();

        TravelType GetById(int code);

        int add(TravelType newType);

        bool Delete(int code);

    }
}
