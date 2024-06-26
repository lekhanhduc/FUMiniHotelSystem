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
    public class BookingReservationRepository : IBookingReservationRepository
    {

        public List<BookingReservation> GetBookingReservations () => BookingReservationDAO.GetBookingReservations();

        public BookingReservation GetBookingReservationById(int id) => BookingReservationDAO.GetBookingReservationById(id);

        public void SaveBookingReservation(BookingReservation bookingReservation) => BookingReservationDAO.SaveBookingReservation(bookingReservation);

        public void UpdateBookingReservation(BookingReservation bookingReservation) => BookingReservationDAO.UpdateBookingReservation(bookingReservation);

        public void DeleteBookingReservation(BookingReservation bookingReservation) => BookingReservationDAO.DeleteBookingReservation(bookingReservation);

    }
}
