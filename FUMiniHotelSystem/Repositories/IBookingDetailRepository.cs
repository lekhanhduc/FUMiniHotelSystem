﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {

        List<BookingDetail> GetBookingDetails();

        void SaveBookingDetail(BookingDetail bookingDetail);

        void UpdateBookingDetail(BookingDetail bookingDetail);

        void DeleteBookingDetail(BookingDetail bookingDetail);

        BookingDetail GetBookingDetailById(int bookingReservationId, int roomId);

    }
}
