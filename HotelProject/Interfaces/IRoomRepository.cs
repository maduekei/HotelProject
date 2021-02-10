using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.Models;

namespace HotelProject.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<RoomsClass>> GetAllRooms();
        Task<List<RoomsClass>> GetFreeRooms();

        Task<bool> AddRoomsAsync(RoomsClass rooms);

        Task<bool> MarkRoomAsOccupiedAsync(int id);
        Task<bool> ReleaseRoomAsync(int idl);

    }
}
