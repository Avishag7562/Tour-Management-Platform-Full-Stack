using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class TripController : Controller
    {
        ITripBLL tripBll;

        public TripController(ITripBLL t)
        {
            tripBll = t;
        }    
        

        [HttpGet ("GetAllTripToUser")]
        public ActionResult<List<TripDTO>> GetAllTripToUser()
        {
            return Ok(tripBll.getAll());
        }


        [HttpGet ("GetTripById")]
        public ActionResult<TripDTO> GetTripById(int code)
        {
            return Ok(tripBll.GetById(code));
        }

        [HttpPut("GetInvitesToTrip")]
        public ActionResult<List<OrderPlaceDTO>> GetInvitesToTrip(int code)
        {
            return Ok(tripBll.GetInvitesToTrip(code));
        }


        [HttpPost ("AddTrip")]
        public ActionResult<int> AddTrip(TripDTO newTrip) 
        {
            return Ok(tripBll.add(newTrip));
        }


        [HttpPut ("UpdateTrip")]
        public ActionResult<bool> UpdateTrip(TripDTO newTrip)
        {
            return Ok(tripBll.update(newTrip));
        }


        [HttpDelete ("DeleteTrip")]
        public ActionResult<bool> DeleteTrip(int code)
        {
            return Ok(tripBll.Delete(code));
        }      
    
    }
}
