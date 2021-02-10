using HotelProject.Data;
using HotelProject.Interfaces;
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
    public class DashBoardController : ControllerBase
    {
        private readonly IDashboardRepository _repo;

        public DashBoardController(IDashboardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("Revenue")]
        public  async Task<IActionResult> AmountEarned()
        {
            var sum = await _repo.TotalAmountAsync();

            return Ok(sum);


        }

        [HttpGet("Customerbase")]
        public async Task<IActionResult> NumberofCustomers()
        {
            var sum = await _repo.NumberofCustomersAsync();

            return Ok(sum);


        }

        [HttpGet("GuestsOrBookings")]
        public async Task<IActionResult> NumberofGuest()
        {
            var sum = await _repo.NumberofGuestAsync();

            return Ok(sum);


        }


    }
}
