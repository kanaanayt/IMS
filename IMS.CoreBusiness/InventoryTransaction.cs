using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class InventoryTransaction
    {
        [Required]
        public int InventoryTransactionId { get; set; }

        [Required]
        public string PoNumber { get; set; } = String.Empty;
        
        [Required]
        public int InventoryId { get; set; }

        [Required]
        public string Author { get; set; } = String.Empty;
        public double UnitPrice { get; set; }

        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public int QuantityAfter { get; set;}

        [Required]
        public DateTime TransactionDate { get; set; }

        public InventoryTransactionType Activity { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
