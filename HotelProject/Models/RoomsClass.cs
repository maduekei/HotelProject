using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class RoomsClass
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public bool AvailabilityStatus { get; set; }
    }
}
