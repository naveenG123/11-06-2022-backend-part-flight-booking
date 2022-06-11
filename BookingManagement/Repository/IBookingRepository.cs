using BookingManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
   public interface IBookingRepository
    {
        IEnumerable<BookflightTbl> GetBookingDetail();
        void CancelBooking(int id);

        IEnumerable<TicketDetail> GetBookingDetailFromPNR(string pnr);
        IEnumerable<TicketDetail> GetUserHistory(string emailId);

        void AddBookingDetail(BookflightTbl tbl);

        void SaveChanges();
        
    }
}
