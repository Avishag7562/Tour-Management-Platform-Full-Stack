using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class UserController : Controller
    {

        IUserBLL userBll;

        public UserController(IUserBLL u)
        {
            userBll = u;
        }

        [HttpGet ("GetAllUsers")]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            return Ok(userBll.getAll());
        }

        [HttpGet ("GetUserByMailAndPassword")]
        public ActionResult<UserDTO> GetUserByMailAndPassword(string email, string password)
        {
            return Ok(userBll.GetByMailAndPassword(email, password));
        }

        [HttpGet("GetAllTripToUser")]
        public ActionResult<UserDTO> GetUserByMailAndPassword(string email, string password)
        {
            return Ok(userBll.GetByMailAndPassword(email, password));
        }

        [HttpPost ("AddUser")]
        public ActionResult<int> AddUser(UserDTO user) 
        {
            return Ok(userBll.add(user));
        }

        [HttpPut("UpdateUser")]
        public ActionResult<bool> UpdateUser(UserDTO newUser)
        {
            return Ok(userBll.update(newUser));
        }

        [HttpDelete ("DeleteUser")]
        public ActionResult<bool> DeleteUser(int id)
        {
            return Ok(userBll.Delete(id));
        }
    }
}
