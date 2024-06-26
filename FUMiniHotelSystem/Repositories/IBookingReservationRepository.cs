using BusinessObject;
using System.Collections.ObjectModel;

namespace Repositories
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetBookingReservations();

        void SaveBookingReservation(BookingReservation bookingReservation);

        void UpdateBookingReservation(BookingReservation bookingReservation);

        void DeleteBookingReservation(BookingReservation bookingReservation);

        BookingReservation GetBookingReservationById(int id);

    }
}
