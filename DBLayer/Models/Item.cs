using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Threshold { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public enum ItemType
        {
            FirePreventionSupplies=1,
            FirstAidSupplies,
            OfficeSupplies
        } 

        public ItemType Type { get; set; }

        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? ExpireFEDate { get; set;}


        public IEnumerable<Alert> Alerts { get; set; }
    }
}
