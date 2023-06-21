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

        public async Task EditInventoryItemAsync(Inventory inventory)
        {
            if (await ExistsAsync(inventory))
            {
                return;
            }

            var match = _inventories.FirstOrDefault(inv => inv.InventoryId == inventory.InventoryId);

            if (match != null)
            {
                match.InventoryName = inventory.InventoryName;
                match.Quantity = inventory.Quantity;
                match.Price = inventory.Price;
            }

            return;
        }

        public async Task<bool> ExistsAsync(Inventory inventory)
        {
            return await Task.FromResult(_inventories.Any(inv =>
                inv.InventoryId != inventory.InventoryId &&
                inv.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            var inventory = _inventories.FirstOrDefault(inv => inv.InventoryId == inventoryId);
            Inventory copy = new();

            if (inventory != null)
            {
                copy.InventoryId = inventory.InventoryId;
                copy.InventoryName = inventory.InventoryName;
                copy.Price = inventory.Price;
                copy.Quantity = inventory.Quantity;
            }

            return await Task.FromResult(copy);
        }

        public async Task PurchaseInventoryAsync(Inventory inventory, int purchaseQuantity, 
                                                 string author, string poNumber)
        {
            var Inventory = await Task.FromResult(_inventories.FirstOrDefault(inv =>
                inv.InventoryId == inventory.InventoryId));

            if (Inventory != null)
                Inventory.Quantity += purchaseQuantity;


        }
    }
}