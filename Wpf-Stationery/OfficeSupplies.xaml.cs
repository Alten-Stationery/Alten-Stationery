using Alten_Stationery;
using DBLayer;
using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.Repositories;
using DBLayer.UOW;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for OfficeSupplies.xaml
    /// </summary>
    public partial class OfficeSupplies : Page
    {
        public ICommand YourCommand { get; set; }
        public IItemsService _service { get; set; }

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        // Declare the array variable.
        object[] rowArray = new object[7];

        public OfficeSupplies()
        {
            _service = App.ServiceProvider.GetRequiredService<IItemsService>();
            
            InitializeComponent();
            LoadData();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_BackToHome(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AddItem(object sender, RoutedEventArgs e)
        {

        }

        public async Task<IEnumerable<Item>> LoadData()
        {
            IEnumerable<Item> items;

            try
            {
                // Creazione di un DataTable con alcune colonne
                dataTable = new DataTable();
                dataTable = MakeTableWithAutoIncrement();
                dr = null;

                items = await _service.GetAllAsync();

                #region GetAllDB
                foreach (var item in items)
                {

                    #region mapping data table visivo
                    rowArray[0] = item.Name;
                    rowArray[1] = item.Threshold;
                    rowArray[2] = item.Description;
                    rowArray[3] = item.Location;
                    //rowArray[4] = item.Type;
                    rowArray[4] = item.Quantity;
                    rowArray[5] = item.ExpirationDate;
                    rowArray[6] = item.ExpireFEDate;
                    #endregion

                    dr = dataTable.NewRow();
                    dr.ItemArray = rowArray;
                    dataTable.Rows.Add(dr);
                }
                #endregion

                if (dataTable != null)
                {
                    //Ridimensiona();

                    CustomerGrid.Visibility = Visibility.Visible;
                    //Set the DataGrid's DataContext to be a filled DataTable
                    CustomerGrid.DataContext = dataTable;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
            return items; 
        }

        private void Resetta()
        {
            this.Height = 550; this.Width = 900;
        }

        private void Ridimensiona()
        {
            this.Width = 1100;
            this.Height = 900;
        }

        private DataTable MakeTableWithAutoIncrement()
        {
            // Make a table with one AutoIncrement column.
            DataTable table = new DataTable("table");

            DataColumn name = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn threshold = new DataColumn("Threshold", Type.GetType("System.String"));
            DataColumn description = new DataColumn("Description", Type.GetType("System.String"));
            DataColumn location = new DataColumn("Location", Type.GetType("System.String"));
            //DataColumn type = new DataColumn("Type", Type.GetType("System.String"));
            DataColumn quantity = new DataColumn("Quantity", Type.GetType("System.String"));
            DataColumn expirationDate = new DataColumn("ExpirationDate", Type.GetType("System.String"));
            DataColumn expireFEDate = new DataColumn("ExpireFEDate", Type.GetType("System.String"));

            table.Columns.Add(name);
            table.Columns.Add(description);
            table.Columns.Add(threshold);
            table.Columns.Add(location);
            //table.Columns.Add(type);
            table.Columns.Add(quantity);
            table.Columns.Add(expirationDate);
            table.Columns.Add(expireFEDate);

            return table;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleted_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       

    }
}
