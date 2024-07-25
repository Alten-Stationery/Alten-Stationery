using OfficeOpenXml.Table.PivotTable;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static DBLayer.Models.Item;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for FilterWindows.xaml
    /// </summary>
    public partial class FilterWindows : Window
    {
        public FilterWindows()
        {
            InitializeComponent();
        }

        private void ButtonSvuota_Click(object sender, RoutedEventArgs e)
        {
            thresholdText.Text = string.Empty;
            locationText.Text = string.Empty;
            typeText.Text = string.Empty;
            quantityText.Text = string.Empty;

            thresholdMinor.IsEnabled = true;
            thresholdMajor.IsEnabled = true;
            quantityMinor.IsEnabled = true;
            quantityMajor.IsEnabled = true;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            int threshold = 0;
            string location = string.Empty;
            string typeString = string.Empty;
            ItemType type = ItemType.OfficeSupplies;
            int quantity = 0;

            List<string> lstFilter = new List<string>();

            try { threshold = Int32.Parse(thresholdText.Text); } catch (Exception ex) { threshold = 0; };
            try { location = locationText.Text; } catch (Exception ex) { location = string.Empty; };
            try
            {
                if (typeText.Text.Equals("OfficeSupplies"))
                {
                    type = ItemType.OfficeSupplies;
                }
                else if(typeText.Text.Equals("FirstAidSupplies"))
                {
                    type = ItemType.FirstAidSupplies;
                }
                else if (typeText.Text.Equals("FirePreventionSupplies")) {
                    type = ItemType.FirePreventionSupplies;
                }
            }
            catch (Exception ex) { type = ItemType.OfficeSupplies; };
            try { quantity = Int32.Parse(quantityText.Text); } catch (Exception ex) { quantity = 0; };

            OfficeSupplies officeSupplies = new OfficeSupplies();

            officeSupplies.AddFilter(threshold, location, type, quantity);

        }

        private void ButtonMinor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMajor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLocationEquals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTypeEquals_Click(object sender, RoutedEventArgs e)
        {

        }

      


        private void ButtonThresholdMinor_Click(object sender, RoutedEventArgs e)
        {
            thresholdMinor.IsEnabled = false;
            thresholdMajor.IsEnabled = true;
        }

        private void ButtonThresholdMajor_Click(object sender, RoutedEventArgs e)
        {
            thresholdMajor.IsEnabled = false;
            thresholdMinor.IsEnabled = true;

        }

        private void ButtonQuantityMinor_Click(object sender, RoutedEventArgs e)
        {
            quantityMinor.IsEnabled = false;
            quantityMajor.IsEnabled = true;
        }

        private void ButtonQuantityMajor_Click(object sender, RoutedEventArgs e)
        {
            quantityMajor.IsEnabled = false;
            quantityMinor.IsEnabled = true;
        }
    }
}
