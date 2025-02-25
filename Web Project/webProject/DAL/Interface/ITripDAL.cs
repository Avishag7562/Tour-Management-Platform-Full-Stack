using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITripDAL
    {
        List<Trip> getAll();

        Trip GetById(int code);

        int add(Trip newTrip);

        bool Delete(int code);

        bool update(Trip newT);
        
    }
}
