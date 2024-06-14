using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public DateTime AlertDate { get; set; }
        public string Email { get; set; }
        public string EmailBody { get; set; }

        public Refill? Refill { get; set; }
        public int? RefillId { get; set; }//nullable per il momento
        public Item Item {  get; set; }
        public int ItemId { get; set; }

    }
}
