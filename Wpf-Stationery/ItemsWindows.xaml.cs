using DBLayer.Models;
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
using static System.Net.Mime.MediaTypeNames;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for ItemsWindows.xaml
    /// </summary>
    public partial class ItemsWindows : Window
    {
        public ItemsWindows()
        {
            InitializeComponent();

            nameText.Text = "test";
            descriptionText.Text = "description";
            thresholdText.Text = "thresholdText";
            locationText.Text = " location";
            quantityText.Text = "quantity";
            expirationDateText.Text = "expirationDate";
            expireFEDateText.Text = "expireFEDate";
        }

        public ItemsWindows(Item item)
        {
            InitializeComponent();

            nameText.Text = item.Name;
            descriptionText.Text = item.Description;
            thresholdText.Text = item.Threshold.ToString();
            locationText.Text = item.Location;
            quantityText.Text = item.Quantity.ToString();
            expirationDateText.Text = item.ExpirationDate.ToString();
            expireFEDateText.Text = item.ExpireFEDate.ToString();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_SaveESubmit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
