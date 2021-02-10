using HotelProject.Data;
using HotelProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Services
{
    public class DashboardRepository : IDashboardRepository
    {

        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> NumberofCustomersAsync()
        {
            var customers =   _context.Customer.Count();

            return await Task.FromResult(customers);
        }

        public async Task<long> NumberofGuestAsync()
        {
            var customers = _context.Bookings.Count();

            return await Task.FromResult(customers);
        }

        public async Task<decimal> TotalAmountAsync()
        {
            var customers = _context.Bookings.Sum(x=>x.Amount);

            return await Task.FromResult(customers);
        }
    }
}
