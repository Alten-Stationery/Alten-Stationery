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
using static DBLayer.Models.Item;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for OfficeSupplies.xaml
    /// </summary>
    public partial class OfficeSupplies : Window
    {
        public ICommand YourCommand { get; set; }
        //public IItemsService _service { get; set; }
        private object[] rowArray;
        DataTable dataTable;
        DataRow dr;
        private IItemsService _serviceItem;
        Items items;
        Item item;

        public string NewName;
        public int NewThreshold;
        public string NewDescription;
        public string NewLocation;
        public ItemType NewType;
        public int NewQuantity;
        public DateTime NewExpirationDate;
        public DateTime? NewExpireFEDate;

        public OfficeSupplies()
        {
            dataTable = new DataTable();
            // Declare the array variable.
            rowArray = new object[8];
            items = new Items();
            _serviceItem = App.ServiceProvider.GetRequiredService<IItemsService>();

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
            items = new Items();
            items.Show();


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

                items = await _serviceItem.GetAllAsync();

                #region GetAllDB
                foreach (var item in items)
                {

                    #region mapping data table visivo
                    rowArray[0] = item.ItemId;
                    rowArray[1] = item.Name;
                    rowArray[2] = item.Threshold;
                    rowArray[3] = item.Description;
                    rowArray[4] = item.Location;
                    //rowArray[4] = item.Type;
                    rowArray[5] = item.Quantity;
                    rowArray[6] = item.ExpirationDate;
                    rowArray[7] = item.ExpireFEDate;
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

            DataColumn itemId = new DataColumn("ItemId", Type.GetType("System.String"));
            DataColumn name = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn threshold = new DataColumn("Threshold", Type.GetType("System.String"));
            DataColumn description = new DataColumn("Description", Type.GetType("System.String"));
            DataColumn location = new DataColumn("Location", Type.GetType("System.String"));
            //DataColumn type = new DataColumn("Type", Type.GetType("System.String"));
            DataColumn quantity = new DataColumn("Quantity", Type.GetType("System.String"));
            DataColumn expirationDate = new DataColumn("ExpirationDate", Type.GetType("System.String"));
            DataColumn expireFEDate = new DataColumn("ExpireFEDate", Type.GetType("System.String"));

            table.Columns.Add(itemId);
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
            //Modificol'Item
            var selectedItem = ((System.Data.DataRowView)CustomerGrid.SelectedItem);
            int idSelected = 0;
            item = new Item();
            items = new Items();

            try
            {
                idSelected = int.Parse(selectedItem.Row.ItemArray[0].ToString());

                items.Show();

                item.ItemId = idSelected;
                item.Name = NewName;
                item.Description = NewDescription;
                item.Threshold = NewThreshold;
                item.Location = NewLocation;
                item.Quantity = NewQuantity;
                item.ExpirationDate = NewExpirationDate;
                item.ExpireFEDate = NewExpireFEDate;

                _serviceItem.UpdateAsync(item);

            }
            catch (Exception ex)
            {
                idSelected = -1;
                MessageBox.Show("Impossibile visializzare l'Item");
            }

        }

        private void ButtonDeleted_Click(object sender, RoutedEventArgs e)
        {
            //Seleziono e cancello l'Item
            var selectedItem = ((System.Data.DataRowView)CustomerGrid.SelectedItem);
            int idSelected = 0;

            try
            {
                idSelected = int.Parse(selectedItem.Row.ItemArray[0].ToString());
                _serviceItem.DeleteAsync(idSelected);
                selectedItem.Delete();
            }
            catch (Exception ex)
            {
                idSelected = -1;
                MessageBox.Show("Errore nell'eliminzione!!!");
            }
            
        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
