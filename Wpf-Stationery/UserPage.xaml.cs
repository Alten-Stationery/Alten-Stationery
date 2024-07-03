using Microsoft.AspNetCore.Identity;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Stationery
{
    
    public partial class UserPage : Window
    {
        //private IUsersService _serviceUser;
        //private IItemsService _serviceItem;
        private IService<IItemsService> _service;

        public UserPage(IService<IItemsService> service)
        {
            _service = service;
            //_serviceItem = serviceItem;
            //_serviceUser = serviceUser;
            InitializeComponent();
        }

        public UserPage()
        {
            InitializeComponent();
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
            //MainWindow main = new MainWindow(_service, _userManager, _signInManager);
            //UserPage userPage = new UserPage(_service);
            UserPage userPage = new UserPage();

            OfficeSupplies officeSupplies = new OfficeSupplies();
            officeSupplies.Show();
        }
    }
}
