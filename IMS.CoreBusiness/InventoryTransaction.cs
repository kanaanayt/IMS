using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class InventoryTransaction
    {
        public int TransactionId { get; set; }
        public int InventoryId { get; set; }
        public string PoNumber { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public double UnitPrice { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set;}
        public DateTime TransactionDate { get; set; }
        public InventoryTransactionActivity Activity { get; set; }
    }
}
