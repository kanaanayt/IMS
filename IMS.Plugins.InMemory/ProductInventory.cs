using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductInventory
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
    }
}
