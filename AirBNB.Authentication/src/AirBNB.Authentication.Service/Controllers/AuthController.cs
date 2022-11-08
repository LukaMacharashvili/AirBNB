using AirBNB.Authentication.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using AirBNB.Authentication.Service.Services;
using AirBNB.Authentication.Service.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AirBNB.Authentication.Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("whoami"), Authorize]
        public async Task<ActionResult<User>> Whoami()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.Fetch(id);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            try
            {
                var user = await _userService.RegisterUser(request);
                return Ok(user);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            try
            {
                var token = await _userService.LoginUser(request);
                return Ok(token);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPut("verify-user/{verificationToken}")]
        public async Task<ActionResult> VerifyUser([FromRoute] string verificationToken)
        {
            try
            {
                await _userService.VerifyUser(verificationToken);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPatch, Authorize]
        public async Task<ActionResult<User>> Update(UpdateDto request)
        {
            try
            {
                var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = await _userService.UpdateUser(id, request);
                return Ok(user);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult> Delete()
        {
            try
            {
                var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }
    }
}