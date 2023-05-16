namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}