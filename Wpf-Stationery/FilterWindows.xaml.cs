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

            if (threshold > 0)
            {

            }
            OfficeSupplies officeSupplies = new OfficeSupplies();

            officeSupplies.AddFilter(threshold, location, type, quantity);

        }
    }
}
