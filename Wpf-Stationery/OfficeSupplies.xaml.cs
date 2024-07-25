using Alten_Stationery;
using DBLayer;
using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.Repositories;
using DBLayer.UOW;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
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
        ItemsWindows itemsWindows;
        Item item = new Item();
        IEnumerable<Item> lstItems;
        bool boolRefresh = false;

        public string NewName;
        public int NewThreshold;
        public string NewDescription;
        public string NewLocation;
        public ItemType NewType;
        public int NewQuantity;
        public DateTime NewExpirationDate;
        public DateTime? NewExpireFEDate;
        ItemType type;
        bool boolFilter = false;
        string filterName = string.Empty;
        private IUsersService _service;
        bool boolUpdateOrCreate = false;
        private User user;

        Item itemSelected;

        int threshold = 0;
        string location = string.Empty;
        int quantity = 0;
        bool boolfilterGeneric = false;

        public OfficeSupplies()
        {
            dataTable = new DataTable();
            // Declare the array variable.
            rowArray = new object[7];
            _service = App.ServiceProvider.GetService<IUsersService>();
            _serviceItem = App.ServiceProvider.GetRequiredService<IItemsService>();

            InitializeComponent();

            //Type
            LoadData(boolFilter, filterName, boolRefresh, threshold, location, type:ItemType.OfficeSupplies, quantity);
        }

        public OfficeSupplies(bool boolUpdateOrCreate)
        {
            boolUpdateOrCreate = false;
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
            var userPage = new UserPage(user);
            this.Close();
            userPage.Show();
        }

        private void Button_AddItem(object sender, RoutedEventArgs e)
        {
            Item item = new Item();
            itemsWindows = new ItemsWindows(item);
            itemsWindows.SaveESubmit.Visibility = Visibility.Visible;
            itemsWindows.Show();
        }

        public async Task<IEnumerable<Item>> LoadData(bool boolFilter, string filterName, bool boolRefresh, int threshold, string location, ItemType type, int quantity)
        {
            bool boolFilterName = false;

            if (boolRefresh)
            {
                textBoxName.Text = string.Empty;
            }

            filterName = textBoxName.Text;
            if (!filterName.IsNullOrEmpty())
            {
                boolFilterName = true;
            }

            try
            {
                // Creazione di un DataTable con alcune colonne
                dataTable = new DataTable();
                dataTable = MakeTableWithAutoIncrement();
                dr = null;

                #region Filter
                if (boolFilter)
                {
                    lstItems = await _serviceItem.GetAllAsyncByType(type);
                }
                else if (boolFilterName)
                {
                    lstItems = await _serviceItem.GetAllAsyncByName(filterName, type);
                    //FIND
                }
                else if (boolfilterGeneric)
                {
                    lstItems = await _serviceItem.GetAllWithFilter(threshold, location, type, quantity);
                }
                else
                {
                    //GetAlls Generica
                    //lstItems = await _serviceItem.GetAllAsync();
                    //Filtro sulla pagina per Type OfficeSupplies
                    lstItems = await _serviceItem.GetAllAsyncByType(type);
                }

                #endregion

                #region GetAllDB
                foreach (var item in lstItems)
                {

                    #region mapping data table visivo
                    rowArray[0] = item.ItemId;
                    rowArray[1] = item.Name;
                    rowArray[2] = item.Threshold;
                    rowArray[3] = item.Description;
                    rowArray[4] = item.Location;
                    rowArray[5] = item.Type;
                    rowArray[6] = item.Quantity;
                    //rowArray[7] = item.ExpirationDate;
                    //rowArray[8] = item.ExpireFEDate;
                    #endregion

                    dr = dataTable.NewRow();
                    dr.ItemArray = rowArray;
                    dataTable.Rows.Add(dr);
                }
                #endregion

                if (dataTable != null)
                {
                    //Ridimensiona();

                    //Set the DataGrid's DataContext to be a filled DataTable
                    OfficeSupplicesGrid.DataContext = dataTable;
                    OfficeSupplicesGrid.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstItems;
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
            DataColumn typeDT = new DataColumn("Type", Type.GetType("System.String"));
            DataColumn quantity = new DataColumn("Quantity", Type.GetType("System.String"));
            //DataColumn expirationDate = new DataColumn("ExpirationDate", Type.GetType("System.String"));
            //DataColumn expireFEDate = new DataColumn("ExpireFEDate", Type.GetType("System.String"));

            table.Columns.Add(itemId);
            table.Columns.Add(name);
            table.Columns.Add(threshold);
            table.Columns.Add(description);
            table.Columns.Add(location);
            table.Columns.Add(typeDT);
            table.Columns.Add(quantity);
            //table.Columns.Add(expirationDate);
            //table.Columns.Add(expireFEDate);

            return table;
        }
        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            LoadData(boolFilter, filterName, boolRefresh, threshold, location, type: ItemType.OfficeSupplies, quantity);
        }
        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            boolFilter = true;

            //LoadData(boolFilter, ItemType.OfficeSupplies, filterName, boolRefresh);

            FilterWindows filterWindows = new FilterWindows();
            filterWindows.Show();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindows(threshold, location, type, quantity);
        }
        public void RefreshWindows(int threshold, string location, ItemType type, int quantity)
        {
            boolRefresh = true;
            boolFilter = false;
            LoadData(boolFilter, filterName, boolRefresh, threshold, location, type: ItemType.OfficeSupplies, quantity);

            boolRefresh = false;
        }
        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            //Download dati
            DownloadExcel();

        }

        private async Task DataTable()
        {
            //Modificol'Item
            var selectedItem = ((System.Data.DataRowView)OfficeSupplicesGrid.SelectedItem);
            int idSelected = 0;
            item = new Item();

            try
            {
                idSelected = int.Parse(selectedItem.Row.ItemArray[0].ToString());
                itemSelected = await _serviceItem.GetById(idSelected);

                itemsWindows = new ItemsWindows(itemSelected);
                itemsWindows.Save.Visibility = Visibility.Visible;
                itemsWindows.Show();

            }
            catch (Exception ex)
            {
                idSelected = -1;
                MessageBox.Show("Impossibile visializzare l'Item");
            }

        }
        private async Task GetAlls()
        {
            lstItems = await _serviceItem.GetAllAsync();
        }

        private void ButtonDeleted_Click(object sender, RoutedEventArgs e)
        {
            //Seleziono e cancello l'Item
            var selectedItem = ((System.Data.DataRowView)OfficeSupplicesGrid.SelectedItem);
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
                MessageBox.Show("Errore nell'eliminzione!!!\n" + ex.Message);
            }

        }

        private void ButtonModify_Click(object sender, RoutedEventArgs e)
        {
            itemsWindows = new ItemsWindows(item);
            itemsWindows.Save.Visibility = Visibility.Visible;
            DataTable();
        }
        public string DownloadExcel()
        {
            #region MyRegion
            // If you are a commercial business and have
            // purchased commercial licenses use the static property
            // LicenseContext of the ExcelPackage class:
            //ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            #endregion

            string filePath = string.Empty;

            string fileName = "Lista_items" + ".xlsx";
            int year = DateTime.Now.Year;
            //string userName = Environment.UserName;
            //string pathFolderForDay = "C:\\Users\\" + userName + "\\Downloads\\" + appConfig.Where(x => x.Field == "PathReport").SingleOrDefault().Value;
            string pathFolderForDay = "C:" + "\\Downloads" + "\\Items";

            //Creo la cartella per le transazioni in base al giorno
            if (!Directory.Exists(pathFolderForDay))
            {
                Directory.CreateDirectory(pathFolderForDay);
            }
            filePath = pathFolderForDay + "\\" + fileName;

            try
            {
                DataSet ds = new DataSet("New_DataSet");
                DataTable dt = new DataTable("New_DataTable");

                //Set the locale for each
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                if (lstItems != null && lstItems.Count() > 0)
                {
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Threshold");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Location");
                    //dt.Columns.Add("Type");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("ExpirationDate");
                    dt.Columns.Add("ExpireFEDate");

                    foreach (var item in lstItems)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Name"] = item.Name;
                        dr["Threshold"] = item.Threshold;
                        dr["Description"] = item.Description;
                        dr["Location"] = item.Location;
                        //dr["Type"] = item.Type;
                        dr["Quantity"] = item.Quantity;
                        dr["ExpirationDate"] = item.ExpirationDate;
                        dr["ExpireFEDate"] = item.ExpireFEDate;

                        dt.Rows.Add(dr);
                    }
                    //Add the table to the data set
                    ds.Tables.Add(dt);

                    using (var excel = new ExcelPackage())
                    {
                        var worksheet = excel.Workbook.Worksheets.Add("Items");

                        //Riga 1, Colonna 1
                        worksheet.Cells[1, 1].LoadFromDataTable(dt, true);
                        FileInfo excelFile = new FileInfo(filePath);
                        excel.SaveAs(excelFile);
                    };

                    MessageBox.Show("Download eseguito!!!\n" + filePath);

                }
                else
                {
                    //items not found
                    filePath = string.Empty;
                }

            }
            catch (Exception ex)
            {
                //log.Error("DownloadExcel: ", ex);
            }
            return filePath;
        }

        private void OfficeSupplicesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void AddFilter(int threshold, string location, ItemType type, int quantity)
        {
            boolfilterGeneric = true;

            RefreshWindows(threshold, location, type, quantity);

            boolfilterGeneric = false;
        }
    }
}
