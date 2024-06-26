using BusinessObject;
using CustomerManagement;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private readonly ICustomerService iCustomerService;

        public LoginWindow()
        {
            InitializeComponent();
            iCustomerService = new CustomerService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Customer account = iCustomerService.GetCustomerById(txtUser.Text);
            if (account != null && account.Password.Equals(txtPass.Password) && account.CustomerFullName.Equals("William Shakespeare"))
            { 
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }else if (account != null && account.Password.Equals(txtPass.Password))
            {
                this.Hide();
                CustomerProfile customerProfile = new CustomerProfile(account);
                customerProfile.Show();
            }
            else
            {
                MessageBox.Show("You are not perrmision !");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
