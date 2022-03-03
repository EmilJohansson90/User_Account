using DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace User_Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("/AddUser")]
        public IActionResult AddUser(AddUserDTO addUserDTO)
        {
            if(UserService.Instance.CheckUserName(addUserDTO))
            {
                return StatusCode(401);
            }
            else
            {
                UserService.Instance.AddUser(addUserDTO);
                return Ok();
            }
        }
    }
}
