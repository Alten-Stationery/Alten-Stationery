using DBLayer;
using DBLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static DBLayer.Models.Item;
using static System.Net.Mime.MediaTypeNames;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for ItemsWindows.xaml
    /// </summary>
    public partial class ItemsWindows : Window
    {

        private IItemsService _serviceItem;
        private Item _item;
        bool boolCreateOrUpdate = false;
        int countClick = 0;

        public ItemsWindows(Item itemSelected, bool boolCreateOrUpdate, int countClick)
        {
            _item = itemSelected;
            _serviceItem = App.ServiceProvider.GetRequiredService<IItemsService>();

            InitializeComponent();

            if (countClick > 0)
            {
                nameText.Text = itemSelected.Name;
                descriptionText.Text = itemSelected.Description;
                thresholdText.Text = itemSelected.Threshold.ToString();
                locationText.Text = itemSelected.Location;
                quantityText.Text = itemSelected.Quantity.ToString();
                expirationDateText.Text = itemSelected.ExpirationDate.ToString();
                expireFEDateText.Text = itemSelected.ExpireFEDate.ToString();
            }
           
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            var officeSupplies = new OfficeSupplies();
            this.Close();
            officeSupplies.Show();
        }
        private void Button_SaveESubmit(object sender, RoutedEventArgs e)
        {
            try { _item.Name = nameText.Text; } catch (Exception ex) { _item.Name = ""; };
            try { _item.Description = descriptionText.Text; } catch (Exception ex) { _item.Description = ""; };
            try { _item.Location = locationText.Text; } catch (Exception ex) { _item.Location = ""; };
            try { _item.Type = ItemType.OfficeSupplies; } catch (Exception ex) { _item.Type = ItemType.OfficeSupplies; };
            try { _item.Quantity = Int32.Parse(quantityText.Text); } catch (Exception ex) { _item.Quantity = 0; };
            try { _item.ExpirationDate = DateTime.Parse(expirationDateText.Text); } catch (Exception ex) { _item.ExpirationDate = DateTime.Now; };
            try { _item.ExpireFEDate = DateTime.Parse(expireFEDateText.Text); } catch (Exception ex) { };

            //if (boolCreateOrUpdate)
            //{
                
            //}
            //else
            //{
            //    //InsertItem();
            //    CreateAsync(_item);
            //}

            if (countClick > 0)
            {
                UpdateAsync(_item);
                this.Close();
            }
            else
            {
                //InsertItem();
                CreateAsync(_item);
                this.Close();
            }

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


        private void InsertItem()
        {
            var connectionString = App.Configuration.GetConnectionString("StationeryDB");
            var dt = new DataTable();

            //var properties = typeof( Items ).GetProperties()
            //    .Where( p => !p.GetCustomAttributes( false ).Any( attr => attr.GetType() == typeof( ObsoleteAttribute ) ) );
            //foreach ( var property in properties ) {
            //    dt.Columns.Add( property.Name );
            //}

            dt.Columns.Add("ItemId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Threshold");
            dt.Columns.Add("Description");
            dt.Columns.Add("Location");
            dt.Columns.Add("Type");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("ExpirationDate");
            dt.Columns.Add("ExpireFEDate");

            DataRow dr = dt.NewRow();

            dr["Name"] = nameText.Text;
            dr["Threshold"] = descriptionText.Text;
            dr["Description"] = thresholdText.Text;
            dr["Location"] = locationText.Text;
            dr["Type"] = ItemType.OfficeSupplies;
            dr["Quantity"] = quantityText.Text;
            dr["ExpirationDate"] = expirationDateText.Text;
            dr["ExpireFEDate"] = expireFEDateText.Text;
            dt.Rows.Add(dr);

            //Inserisco il record relativo al file caricato
            using (var sqlBulk = new SqlBulkCopy(connectionString))
            {
                sqlBulk.NotifyAfter = 1;
                sqlBulk.SqlRowsCopied += (sender, eventArgs) => Console.WriteLine("Wrote " + eventArgs.RowsCopied + " records.");
                sqlBulk.DestinationTableName = "Items";
                sqlBulk.WriteToServer(dt);
            }
        }

        //Update Item
        public void UpdateDbItem(int insertedid, string nameNew, int thresholdNew)
        {
            //using (var context = new Entities())
            //{
            //    Item item = context.Item.SingleOrDefault(x => x.PIDailyChargesID == insertedid);
            //    item.Name = nameNew;
            //    item.Threshold = thresholdNew;
            //    context.SaveChanges();
            //}
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await _serviceItem.CreateAsync(item);
            return item;
        }
        public async Task<Item> UpdateAsync(Item item)
        {
            await _serviceItem.UpdateAsync(item);
            return item;
        }

    }
}
