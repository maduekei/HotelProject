using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomersClass> GetCustomerByID(int ID);
        Task<List<CustomersClass>> GetAllCustomersAsync();
        Task<bool> AddCustomerAsync(CustomersClass model);
        Task<bool> DeleteCustomerAsync(int ID);
            
    }
}
