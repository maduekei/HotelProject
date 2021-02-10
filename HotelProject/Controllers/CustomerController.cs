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
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomersClass model)
        {
          var result = await _repo.AddCustomerAsync(model);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _repo.DeleteCustomerAsync(id);
            return Ok(result);
        }
       
        [HttpGet("{id}CustomerById")]
        public async Task<IActionResult> GetCustomerByID(int id)
        {
            var result = await _repo.GetCustomerByID(id);
            return Ok(result);

        }

        [HttpGet("AllCustomers")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _repo.GetAllCustomersAsync();
            return Ok(result);

        }


    }
}
