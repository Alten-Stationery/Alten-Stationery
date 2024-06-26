using DBLayer.UOW;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public ObservableCollection<Item> YourItemsSource { get; set; }
        public ICommand YourCommand { get; set; }

        private readonly IUnitOfWork _unitOfWork;


        DataTable dataTable = new DataTable();
        DataRow dr = null;
        // Declare the array variable.
        object[] rowArray = new object[6];

        public OfficeSupplies()
        {
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

        private void LoadData()
        {
            // Creazione di un DataTable con alcune colonne
            dataTable = new DataTable();
            dataTable = MakeTableWithAutoIncrement();
            dr = null;

            int countRowsdt = dataTable.Rows.Count;

            IItemsService itemsService = new ItemsService(_unitOfWork);

            //IEnumerable<Item> items = _unitOfWork.Items.GetAllAsync();
            //var items = itemsService.GetAllAsync();

            //IEnumerable<Item> items = itemsService.GetAllAsync();
            //var items = itemsService.GetAllAsync();

            for (int i = 0; i < 5; i++)
            {
                {
                    #region mapping data table visivo
                    rowArray[0] = "Foglio";
                    rowArray[1] = 15;
                    //rowArray[2] = item.Categories;
                    rowArray[2] = "Categories";
                    rowArray[3] = "Description";
                    rowArray[4] = "Location";
                    rowArray[5] = 10;
                    //rowArray[6] = "ACTION";
                    //rowArray[7] = "DELETED";
                    #endregion

                    dr = dataTable.NewRow();
                    dr.ItemArray = rowArray;
                    dataTable.Rows.Add(dr);
                }
            }

            //foreach (var item in items)
            //{

            //    #region mapping data table visivo
            //    rowArray[0] = item.Name;
            //    rowArray[1] = item.Quantity;
            //    //rowArray[2] = item.Categories;
            //    rowArray[2] = "Categories";
            //    rowArray[3] = item.Description;
            //    rowArray[4] = item.Location;
            //    rowArray[5] = item.Threshold;
            //    rowArray[6] = "ACTION";
            //    rowArray[7] = "DELETED";
            //    #endregion

            //    dr = dataTable.NewRow();
            //    dr.ItemArray = rowArray;
            //    dataTable.Rows.Add(dr);
            //}

            #region Column DataTable 
            //dataTable.Columns.Add("ID", typeof(int));
            //dataTable.Columns.Add("Name", typeof(string));
            //dataTable.Columns.Add("Quantity", typeof(int));
            //dataTable.Columns.Add("Categories", typeof(string));
            //dataTable.Columns.Add("Description", typeof(string));
            //dataTable.Columns.Add("Location", typeof(string));
            //dataTable.Columns.Add("Threshold", typeof(string));
            //dataTable.Columns.Add("Action", typeof(int));
            //dataTable.Columns.Add("Deleted", typeof(int));

            //// Aggiunta di alcune righe di esempio
            //dataTable.Rows.Add(1, "Post-it", 30);
            //dataTable.Rows.Add(2, "10", 25);
            //dataTable.Rows.Add(3, "Internet Bill", 35);
            //dataTable.Rows.Add(4, "Post-it", 35);
            //dataTable.Rows.Add(5, "First locker", 35);
            //dataTable.Rows.Add(6, "500/-", 35);
            //dataTable.Rows.Add(7, "Modify", 35);
            //dataTable.Rows.Add(8, "Deleted", 35);

            // Imposta la proprietà ItemsSource della DataGrid
            //dataGridItems.ItemsSource = dataTable.DefaultView;
            #endregion

            if (dataTable != null)
            {
                //Ridimensiona();

                //Set the DataGrid's DataContext to be a filled DataTable
                CustomerGrid.DataContext = dataTable;
            }

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
            DataColumn quantity = new DataColumn("Quantity", Type.GetType("System.String"));
            DataColumn categories = new DataColumn("Categories", Type.GetType("System.String"));
            DataColumn description = new DataColumn("Description", Type.GetType("System.String"));
            DataColumn location = new DataColumn("Location", Type.GetType("System.String"));
            DataColumn threshold = new DataColumn("Threshold", Type.GetType("System.String"));
            //DataColumn action = new DataColumn("Action", Type.GetType("System.String"));
            //DataColumn deleted = new DataColumn("Deleted", Type.GetType("System.String"));

            table.Columns.Add(name);
            table.Columns.Add(quantity);
            table.Columns.Add(categories);
            table.Columns.Add(description);
            table.Columns.Add(location);
            table.Columns.Add(threshold);
            //table.Columns.Add(action);
            //table.Columns.Add(deleted);

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


    }
}
