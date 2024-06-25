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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            
            //OfficeSupplies officeSupplies = new OfficeSupplies();
            //this.NavigationService.Navigate(officeSupplies);

            #region Navigation
            //Create a NavigationWindow
            //NavigationWindow navWindow = new NavigationWindow();
            Dashboard dashboard = new Dashboard();
            //Navigate to Menu.xaml
            //dashboard.Navigate(new Uri("Menu.xaml", UriKind.Relative));

            //Navigate to Page2.xaml
            dashboard.Navigate(new Uri("OfficeSupplies.xaml", UriKind.Relative));
            #endregion


        }

        private void Link_Dashboard(object sender, RoutedEventArgs e)
        {

        }

        private void Link_Logout(object sender, RoutedEventArgs e)
        {

        }

        private void Link_Users(object sender, RoutedEventArgs e)
        {

        }

        private void Link_AddItem(object sender, RoutedEventArgs e)
        {

        }

        private void Link_Orders(object sender, RoutedEventArgs e)
        {

        }

        private void Link_Allerts(object sender, RoutedEventArgs e)
        {

        }
    }
}
