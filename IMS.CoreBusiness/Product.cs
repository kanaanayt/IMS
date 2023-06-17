using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage="Invalid Product Name")]
        public string ProductName { get; set; } = String.Empty;

        [Required]
        [Range(1, 500, ErrorMessage="Invalid Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage="Invalid Price")]
        public double Price { get; set; }

        public List<ProductInventory> ProductInventories { get; set; } = new();

        public void AddProductInventory(Inventory inventory)
        {
            bool duplicate = this.ProductInventories.Any(prodInv =>
                prodInv.Inventory != null &&
                prodInv.Inventory.InventoryName.Equals(inventory.InventoryName));

            if (!duplicate)
            {
                this.ProductInventories.Add(
                    new ProductInventory
                    {
                        InventoryId = inventory.InventoryId,
                        Inventory = inventory,
                        InventoryQuantity = 1,
                        ProductId = this.ProductId,
                        Product = this
                    }
                );
            }
        }
    }
}
