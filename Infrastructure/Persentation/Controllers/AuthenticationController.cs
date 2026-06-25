using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.Authentication;
using Shared.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class AuthenticationController(IAuthenticationService _AuthService):ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>>Login(LoginDto loginDto)
        {
            var res = await _AuthService.Login(loginDto);
            return Ok(res);
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> Register(RegisterDto RegisterDto)
        {
            var res = await _AuthService.Register(RegisterDto);
            return Ok(res);
        }
    }
}
