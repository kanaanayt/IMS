using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>
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
            if (String.IsNullOrWhiteSpace(invName)) 
                return await Task.FromResult(_inventories);

            var inventories = _inventories.Where(inv =>
                inv.InventoryName.Contains(invName, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(inventories);
           
        }

        public Task AddInventoryItemAsync(Inventory inventory)
        {
            if (_inventories.Any(inv => String.Equals(inv.InventoryName,
                inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            inventory.InventoryId = _inventories.Count + 1;
            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public Task EditInventoryItemAsync(Inventory inventory)
        {
            if (_inventories.Any(inv => 
                inv.InventoryId != inventory.InventoryId &&
                inv.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var match = _inventories.FirstOrDefault(inv => inv.InventoryId == inventory.InventoryId);

            if (match != null)
            {
                match.InventoryName = inventory.InventoryName;
                match.Quantity = inventory.Quantity;
                match.Price = inventory.Price;
            }

            return Task.CompletedTask;
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            return await Task.FromResult(_inventories.FirstOrDefault(inv => inv.InventoryId == inventoryId));
        }
    }
}