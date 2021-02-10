using HotelProject.Interfaces;
using HotelProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repo;

        public RoomController(IRoomRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomsinHotel()
        {
          var rooms = await  _repo.GetAllRooms();
            return Ok(rooms);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetFreeRooms()
        //{
        //    var rooms = await _repo.GetFreeRooms();
        //    return Ok(rooms);
        //}

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] RoomsClass model)
        {
            var rooms = await _repo.AddRoomsAsync(model);
            return Ok(rooms);
        }
    }
}
