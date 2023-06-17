using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Invalid name")]
        public string InventoryName { get; set; } = String.Empty;

        [Required]
        [Range(1, 100, ErrorMessage = "Invalid quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Invalid price")]
        public double Price { get; set; }
    }
}