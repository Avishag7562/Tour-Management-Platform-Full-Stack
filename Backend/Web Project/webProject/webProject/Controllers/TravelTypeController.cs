using BLL.DTO;
using BLL.Func;
using BLL.Interface;
using DAL.Func;
using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class TravelTypeController : Controller
    {
        ITravelTypeBLL typeBll;

        public TravelTypeController(ITravelTypeBLL t)
        {
            typeBll = t;
        }

        [HttpGet("GetAllTypes")]
        public ActionResult<List<TravelTypeDTO>> GetAllTypes()
        {
            return Ok(typeBll.getAll());
        }


        [HttpGet("GetTypeById")]
        public ActionResult<TravelTypeDTO> GetTypeById(int code)
        {
            return Ok(typeBll.GetById(code));
        }


        [HttpPost("AddlType")]
        public ActionResult<int> AddlType(TravelTypeDTO newType)
        {
            return Ok(typeBll.add(newType));
        }

        [HttpDelete("DeleteType")]
        public ActionResult<bool> DeleteType(int code)
        {
            return Ok(typeBll.Delete(code));
        }

    }
}
