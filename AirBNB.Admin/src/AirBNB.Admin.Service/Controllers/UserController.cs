using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AirBNB.Admin.Service.Services;
using AirBNB.Admin.Service.Entities;
using AirBNB.Admin.Service.Dtos;

namespace AirBNB.Admin.Service.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<List<User>>> Load()
        {
            try
            {
                var users = await _userService.Load();
                return Ok(users);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<User>> Fetch([FromRoute] int id)
        {
            try
            {
                var user = await _userService.Fetch(id);
                return Ok(user);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(CreateUserDto request)
        {
            try
            {
                var user = await _userService.Create(request);
                return Ok(user);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPut("verify-user/{id}")]
        public async Task<ActionResult> VerifyUser([FromRoute] int id)
        {
            try
            {
                await _userService.VerifyUser(id);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPatch("{id}"), Authorize]
        public async Task<ActionResult<User>> Update([FromBody] UpdateUserDto request, [FromRoute] int id)
        {
            try
            {
                var user = await _userService.UpdateUser(id, request);
                return Ok(user);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userService.Delete(id);
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