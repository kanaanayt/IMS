using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory {

                    InventoryId = 1,
                    InventoryName = "Bike Seat",
                    Price = 2,
                    Quantity = 10

                }, new Inventory {

                    InventoryId = 2,
                    InventoryName = "Bike Body",
                    Price = 15,
                    Quantity = 10

                }, new Inventory {

                    InventoryId = 3,
                    InventoryName = "Bike Pedals",
                    Price = 1,
                    Quantity = 20

                }, new Inventory {

                    InventoryId = 4,
                    InventoryName = "Bike Wheels",
                    Quantity = 20,
                    Price = 8
                }
            };
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string invName)
        {
            if (String.IsNullOrWhiteSpace(invName)) return await Task.FromResult(_inventories);

            return _inventories.Where(inv =>
                inv.InventoryName.Contains(invName, StringComparison.OrdinalIgnoreCase));
        }
    }
}