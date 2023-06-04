using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class ProductInventory
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public int InventoryQuantity { get; set; }
    }
}
