using BusinessObject;
using CustomerManagement;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniHotelSystem
{
    /// <summary>
    /// Interaction logic for RoomInformationManagement.xaml
    /// </summary>
    public partial class RoomInformationManagement : Window
    {
        private readonly IRoomInformationService roomService;

        public RoomInformationManagement()
        {
            InitializeComponent();
            roomService = new RoomInformationService();
        }

        public void LoadRoomList()
        {
            try
            {
                var roomList = roomService.GetRoomInformationList();
                dgData.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading room list");
            }
            finally
            {
                ResetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = new RoomInformation
                {
                    RoomNumber = txtRoomNumber.Text,
                    RoomDetailDescription = txtRoomDetailDescription.Text,
                    RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                    RoomTypeId = int.Parse(txtRoomTypeID.Text),
                    RoomStatus = byte.Parse((cboRoomStatus.SelectedItem as ComboBoxItem).Tag.ToString()),
                    RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text)
                };
                roomService.AddRoomInformation(room);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadRoomList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            RoomInformation selectedRoom = dgData.SelectedItem as RoomInformation;
            if (selectedRoom != null)
            {
                txtRoomID.Text = selectedRoom.RoomId.ToString();
                txtRoomNumber.Text = selectedRoom.RoomNumber;
                txtRoomDetailDescription.Text = selectedRoom.RoomDetailDescription;
                txtRoomMaxCapacity.Text = selectedRoom.RoomMaxCapacity.ToString();
                txtRoomTypeID.Text = selectedRoom.RoomTypeId.ToString();
                cboRoomStatus.SelectedIndex = selectedRoom.RoomStatus == 1 ? 0 : 1;
                txtRoomPricePerDay.Text = selectedRoom.RoomPricePerDay.ToString();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRoomID.Text.Length > 0)
                {
                    RoomInformation room = new RoomInformation
                    {
                        RoomId = int.Parse(txtRoomID.Text),
                        RoomNumber = txtRoomNumber.Text,
                        RoomDetailDescription = txtRoomDetailDescription.Text,
                        RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                        RoomTypeId = int.Parse(txtRoomTypeID.Text),
                        RoomStatus = byte.Parse((cboRoomStatus.SelectedItem as ComboBoxItem).Tag.ToString()),
                        RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text)
                    };
                    roomService.UpdateRoomInformation(room);
                }
                else
                {
                    MessageBox.Show("You must select a room!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadRoomList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRoomID.Text.Length > 0)
                {
                    RoomInformation room = new RoomInformation
                    {
                        RoomId = int.Parse(txtRoomID.Text)
                    };
                    roomService.DeleteRoomInformation(room);
                }
                else
                {
                    MessageBox.Show("You must select a room!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadRoomList();
            }
        }

        private void ResetInput()
        {
            txtRoomID.Text = "";
            txtRoomNumber.Text = "";
            txtRoomDetailDescription.Text = "";
            txtRoomMaxCapacity.Text = "";
            txtRoomTypeID.Text = "";
            cboRoomStatus.SelectedIndex = 0;
            txtRoomPricePerDay.Text = "";
        }

        private void btnManageCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Customer Information page
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnManageRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Room Information page
            // No action needed as we are already in the Room Information Management page
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Create Report page
            this.Hide();
            CreateReportWindow createReportWindow = new CreateReportWindow();
            createReportWindow.Show(); 
        }
    }
}
