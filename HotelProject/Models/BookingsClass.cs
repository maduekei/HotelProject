using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class BookingsClass
    {
        [Key]
        public int BookingID { get; set; }
       
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public decimal Amount { get; set; }
        public int NumberofNights { get; set; }
        public DateTime CheckintDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public bool Checkedout  { get; set; }


    }
}
