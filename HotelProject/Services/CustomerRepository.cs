using HotelProject.Data;
using HotelProject.Interfaces;
using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomerAsync(CustomersClass model)
        {
           _context.Customer.Add(model);
           await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCustomerAsync(int ID)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerID == ID);
            _context.Remove(customer);
           await _context.SaveChangesAsync();

            return await Task.FromResult(true);


        }

        public async Task<List<CustomersClass>> GetAllCustomersAsync()
        {
            var customers = _context.Customer.ToList();
            return await Task.FromResult(customers);
        }

        public async Task<CustomersClass> GetCustomerByID(int ID)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerID == ID);
            return await Task.FromResult(customer);
        }
    }
}
