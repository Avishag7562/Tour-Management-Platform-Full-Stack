using DAL.Func;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IOrederPlaceDAL
    {
        List<OrederPlace> getAll();

        OrederPlace GetById(int code);
        
        int add(OrederPlace newOrder);

        bool Delete(int code);


    }
}
