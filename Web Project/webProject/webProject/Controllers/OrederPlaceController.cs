using BLL.DTO;
using BLL.Func;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class OrederPlaceController : Controller
    {
        IOrederPlaceBLL orderBll;

        public OrederPlaceController(IOrederPlaceBLL o)
        {
            orderBll = o;
        }


        [HttpGet("GetAllOrdersToTrip")]
        public ActionResult<List<OrderPlaceDTO>> GetAllOrdersToTrip(int code)
        {
            return Ok(orderBll.getAllToTrip(code));
        }


        [HttpPost("AddlOrder")]
        public ActionResult<int> AddlOrder(OrderPlaceDTO newOrder)
        {
            return Ok(orderBll.add(newOrder));
        }

        [HttpDelete("DeleteOrder")]
        public ActionResult<bool> DeleteOrder(OrderPlaceDTO o)
        {
            return Ok(orderBll.Delete(o));
        }
    }
}
