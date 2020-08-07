using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_TexasSales.Models.Request;
using WS_TexasSales.Models.Response;
using WS_TexasSales.Services;

namespace WS_TexasSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Atentication([FromBody] AuthRequest auth)
        {
            Response response = new Response();
            var userresponse = _userService.Response(auth);

            if (userresponse == null)
            {
                response.Success = false;
                response.Message = "Invalid User or Password";
                return BadRequest(response);
            }

            response.Success = true;
            response.Data = userresponse;
            return Ok(response);
        }
    }
}
