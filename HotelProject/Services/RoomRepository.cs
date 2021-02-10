using HotelProject.Data;
using HotelProject.Interfaces;
using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRoomsAsync(RoomsClass rooms)
        {
            _context.Room.Add(rooms);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

       public async Task<List<RoomsClass>> GetAllRooms()
        {
            var rooms = _context.Room.ToList();
            return await Task.FromResult(rooms);
        }

        public async Task<List<RoomsClass>> GetFreeRooms()
        {
          

            var freerooms = _context.Room.ToList();
            var result = from fr in freerooms
                         where fr.AvailabilityStatus == true
                         select fr;

            // var rooms =   _context.Bookings.Where(x => _context.Room.Any(y => y.RoomID == x.RoomID)).ToList();
            return  await Task.FromResult( result.ToList() );

            
        }

        public async Task<List<RoomsClass>> GetOccupiedRooms()
        {


            var freerooms = _context.Room.ToList();
            var result = from fr in freerooms
                         where fr.AvailabilityStatus == false
                         select fr;

            // var rooms =   _context.Bookings.Where(x => _context.Room.Any(y => y.RoomID == x.RoomID)).ToList();
            return await Task.FromResult(result.ToList());


        }



        public async Task<bool> MarkRoomAsOccupiedAsync(int id)
        {
            var room = _context.Room.FirstOrDefault(x => x.RoomID == id);

            if (room != null)
            {

                room.AvailabilityStatus = false;
                _context.Update(room);
               await  _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        

        public async Task<bool> ReleaseRoomAsync(int id)
        {

            
            var room = _context.Room.FirstOrDefault(x => x.RoomID == id);

            if (room != null)
            {

                room.AvailabilityStatus = true ;
                _context.Update(room);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
