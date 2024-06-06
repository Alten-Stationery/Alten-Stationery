using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class Refill
    {
        public int RefillId { get; set; }
        public DateTime RefillDate { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<Alert> Alerts { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }

    }
}
