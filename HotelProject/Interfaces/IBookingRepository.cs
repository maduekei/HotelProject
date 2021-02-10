using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> ReserveRoomAsync(BookingsClass req);
        Task<bool> CheckoutAsync(int bookingID);
        Task<List<BookingsClass>> GetAllGuestsAsync();

        Task<List<BookingsClass>> GetAllCheckedOutGuestsAsync();

        Task<List<BookingsClass>> GetAllLodgedGuestsAsync();


    }
}
