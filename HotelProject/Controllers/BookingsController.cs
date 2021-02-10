using HotelProject.Data;
using HotelProject.Interfaces;
using HotelProject.Models;
using HotelProject.Services;
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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _repo;
        private readonly IRoomRepository _repo2;

       

        public BookingsController(IBookingRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost("BookRoom")]
        public async Task<IActionResult> ReserveRoom([FromBody] BookingsClass model)
        {
             
            

            var result = await _repo.ReserveRoomAsync(model);

          // await _repo2.MarkRoomAsOccupiedAsync(model.RoomID); // Mark the room as occupied

            

            return Ok(result);
            
        }

        [HttpGet("AllGuests")]
        public async Task<IActionResult> GetAllAvailableGuests()
        {
           var result = await  _repo.GetAllGuestsAsync();
            return Ok(result);
        }


        [HttpGet("lodged")]
        public async Task<IActionResult> GetAllLOdgedGuests()
        {
            var result = await _repo.GetAllLodgedGuestsAsync();
            return Ok(result);
        }



        [HttpGet("checkedout")]
        public async Task<IActionResult> GetAllCheckedOutGuests()
        {
            var result = await _repo.GetAllCheckedOutGuestsAsync();
            return Ok(result);
        }
        /// <summary>
        /// CheckOut
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}Checkout")]
        public async Task<IActionResult> CheckOut(int id) 
        
        {
            var result = await _repo.CheckoutAsync(id);

           // await _repo2.ReleaseRoomAsync(id) // the room should be released to in readiness for another customer
            return Ok(result);

        }




    }
}
