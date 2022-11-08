using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Dtos;
using AirBNB.Hotels.Service.Services;

namespace AirBNB.Hotels.Service.Controllers
{
    [Route("api/hotel/{adminId}")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;
        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<Hotel>> Load([FromRoute] int adminId)
        {
            try
            {
                var hotels = await _hotelService.Load(adminId);
                return Ok(hotels);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Hotel>> Fetch([FromRoute] int id)
        {
            try
            {
                var hotel = await _hotelService.Fetch(id);
                return Ok(hotel);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Hotel>> Create([FromRoute] int adminId, CreateHotelDto request)
        {
            try
            {
                var hotel = await _hotelService.Create(adminId, request);
                return Ok(hotel);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPatch("{id}"), Authorize]
        public async Task<ActionResult<Hotel>> Update([FromRoute] int adminId, [FromRoute] int id, [FromBody] UpdateHotelDto request)
        {
            try
            {
                var hotel = await _hotelService.Update(adminId, id, request);
                return Ok(hotel);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult<Hotel>> Delete([FromRoute] int adminId, int id)
        {
            try
            {
                await _hotelService.Delete(adminId, id);
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