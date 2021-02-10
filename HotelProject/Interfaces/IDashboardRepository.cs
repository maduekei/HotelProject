using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Interfaces
{
   public interface IDashboardRepository
    {

        Task<Decimal> TotalAmountAsync();

        Task<long> NumberofCustomersAsync();

        Task<long> NumberofGuestAsync();
    }
}
