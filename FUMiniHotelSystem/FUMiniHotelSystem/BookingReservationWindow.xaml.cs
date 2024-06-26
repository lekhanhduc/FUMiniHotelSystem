using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FUMiniHotelSystem
{
    /// <summary>
    /// Interaction logic for BookingReservationWindow.xaml
    /// </summary>
    public partial class BookingReservationWindow : Window
    {
        private Customer currentUser;
        private readonly IBookingReservationService bookingReservationService;


        public BookingReservationWindow(Customer user)
        {
            InitializeComponent();
            currentUser = user;
            bookingReservationService = new BookingReservationService();
            LoadBookingHistory();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadBookingHistory()
        {
            if (currentUser == null || currentUser.BookingReservations == null)
            {
                MessageBox.Show("Invalid user data. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bookingReservations = bookingReservationService.GetBookingReservationList()
                                  .Where(br => br.CustomerId == currentUser.CustomerId)
                                  .Select(br => new
                                  {
                                      br.BookingReservationId,
                                      br.BookingDate,
                                      br.TotalPrice,
                                      BookingStatus = br.BookingStatus == 1 ? "Confirmed" : "Pending"
                                  }).ToList();

            dgBookingHistory.ItemsSource = bookingReservations;
        }

        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerProfile customerProfile = new CustomerProfile(currentUser);
            customerProfile.Show();
        }
    }
}
