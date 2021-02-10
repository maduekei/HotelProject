using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelProject.Models;


namespace HotelProject.Data
{
    public class ApplicationDbContext : DbContext
    {
       

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<BookingsClass> Bookings { get; set; }
        public DbSet<CustomersClass> Customer { get; set; }
        public DbSet<RoomsClass> Room { get; set; }

    }
}
