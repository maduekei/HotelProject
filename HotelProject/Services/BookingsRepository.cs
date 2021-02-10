using HotelProject.Data;
using HotelProject.Interfaces;
using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Services
{
    public class BookingsRepository : IBookingRepository 
    {
        private readonly ApplicationDbContext _context;

        public BookingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckoutAsync(int bookingID)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.BookingID == bookingID);
            if (booking != null)
            {
                booking.Checkedout = true;
               _context.Bookings.Update(booking);
             await   _context.SaveChangesAsync();

                //Release the room
              //  var m = new RoomRepository();
              //await  m.ReleaseRoomAsync(booking.RoomID);
                return await Task.FromResult(true);

            }
            else
            {

                return await Task.FromResult(false);
            }
           
        }

        public async Task<bool> ReserveRoomAsync(BookingsClass req)
        {

            _context.Bookings.Add(req);
                await _context.SaveChangesAsync();

            // Mark the room as occupied
          //  var m = new RoomRepository();
          //await  m.MarkRoomAsOccupiedAsync(req.RoomID);
            
            
            return await Task.FromResult(true);
        }

        public async Task<List<BookingsClass>> GetAllGuestsAsync()
        {

           // var guests = _context.Bookings.Where(x => x.Checkedout==false).ToList();
            var guests = _context.Bookings.ToList();

            return await Task.FromResult(guests);
        }

        public async Task<List<BookingsClass>> GetAllLodgedGuestsAsync()
        {

             var guests = _context.Bookings.Where(x => x.Checkedout==false).ToList();
             

            return await Task.FromResult(guests);
        }


        public async Task<List<BookingsClass>> GetAllCheckedOutGuestsAsync()
        {

            var guests = _context.Bookings.Where(x => x.Checkedout == true).ToList();


            return await Task.FromResult(guests);
        }

    }
}
