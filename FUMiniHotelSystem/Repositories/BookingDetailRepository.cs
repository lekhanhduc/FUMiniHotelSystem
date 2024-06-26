using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();

        public BookingDetail GetBookingDetailById(int bookingReservationId, int roomId) => BookingDetailDAO.GetBookingDetailById(bookingReservationId, roomId);

        public void SaveBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.SaveBookingDetail(bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.UpdateBookingDetail(bookingDetail);

        public void DeleteBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.DeleteBookingDetail(bookingDetail);

    }
}
