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
        public Task AddInventoryItemAsync(Inventory inventory)
        {
            if (_inventories.Any(inv => String.Equals(inv.InventoryName, 
                inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            int count = _inventories.Count;
            inventory.InventoryId = count + 1;

            _inventories.Add(inventory);
            return Task.CompletedTask;
        }
        public Task EditInventoryItemAsync(Inventory inventory)
        {
            if (_inventories.Any(inv => inv.InventoryId != inventory.InventoryId &&
                inv.InventoryName.Equals(inventory.InventoryName, 
                                         StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var invFound = _inventories.FirstOrDefault(inv =>
                inv.InventoryId == inventory.InventoryId);

            if (invFound != null)
            {
                invFound.InventoryName = inventory.InventoryName;
                invFound.Quantity = inventory.Quantity;
                invFound.Price = inventory.Price;
            }

            return Task.CompletedTask;
        }
    }
}