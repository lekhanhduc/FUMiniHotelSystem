using BusinessObject;
using FUMiniHotelSystem;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomerManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService iCustomerService;

        public MainWindow()
        {
            InitializeComponent();
            iCustomerService = new CustomerService();
        }

        public void LoadCustomerList()
        {
            try
            {
                var customerList = iCustomerService.GetCustomerList();
                dgData.ItemsSource = customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of customers");
            }
            finally
            {
                resetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerFullName = txtCustomerFullName.Text,
                    Telephone = txtTelePhone.Text,
                    EmailAddress = txtEmailAddress.Text,
                    CustomerBirthday = DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value),
                    CustomerStatus = byte.Parse((cboCustomerStatus.SelectedItem as ComboBoxItem).Tag.ToString()),
                    Password = pwdPassword.Password
                };
                iCustomerService.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadCustomerList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            Customer selectCustomer = dgData.SelectedItem as Customer;
            if (selectCustomer != null)
            {
                txtCustomerID.Text = selectCustomer.CustomerId.ToString();
                txtCustomerFullName.Text = selectCustomer.CustomerFullName;
                txtTelePhone.Text = selectCustomer.Telephone;
                txtEmailAddress.Text = selectCustomer.EmailAddress;
                dpCustomerBirthday.SelectedDate = selectCustomer.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);
                cboCustomerStatus.SelectedIndex = selectCustomer.CustomerStatus == 1 ? 0 : 1;
                pwdPassword.Password = selectCustomer.Password;
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
                if (txtCustomerID.Text.Length > 0)
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Int32.Parse(txtCustomerID.Text),
                        CustomerFullName = txtCustomerFullName.Text,
                        Telephone= txtTelePhone.Text,
                        EmailAddress = txtEmailAddress.Text,
                        CustomerBirthday = DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value),
                        CustomerStatus = byte.Parse((cboCustomerStatus.SelectedItem as ComboBoxItem).Tag.ToString()),
                        Password = pwdPassword.Password
                    };
                    iCustomerService.UpdateCustomer(customer);
                }
                else
                {
                    MessageBox.Show("You must select a Customer!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadCustomerList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text.Length > 0)
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Int32.Parse(txtCustomerID.Text)
                    };
                    iCustomerService.DeleteCustomer(customer);
                }
                else
                {
                    MessageBox.Show("You must select a Customer!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadCustomerList();
            }
        }

        private void resetInput()
        {
            txtCustomerID.Text = "";
            txtCustomerFullName.Text = "";
            txtTelePhone.Text = "";
            txtEmailAddress.Text = "";
            dpCustomerBirthday.SelectedDate = null;
            cboCustomerStatus.SelectedIndex = 0;
            pwdPassword.Password = "";
        }

        
        private void btnManageCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Customer Information page
            // No action needed as we are already in the Room Information Management page
        }

        private void btnManageRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Room Information page
            this.Hide();
            RoomInformationManagement manageRoomInfoWindow = new RoomInformationManagement();
            manageRoomInfoWindow.Show();
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
