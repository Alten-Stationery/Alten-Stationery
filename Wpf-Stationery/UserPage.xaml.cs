using DBLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
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

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        private IUsersService _service;
        private User _user;
        public UserPage( User user)
        {
            InitializeComponent();
            _service = App.ServiceProvider.GetService<IUsersService>();
            _user = user;
            this.DataContext = _user;

        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var newWindow = new OfficeSupplies();
            this.Close();
            newWindow.Show();
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var newWindow = new PasswordModal(_user);
            newWindow.Show();
        }
    }
}
