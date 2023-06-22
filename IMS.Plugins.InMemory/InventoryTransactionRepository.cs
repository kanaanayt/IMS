using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private List<InventoryTransaction> _inventoryTransactions = new();

        public Task PurchaseAsync(Inventory inventory, 
                                  int quantity,
                                  double price,
                                  string poNumber,
                                  string author)
        {
            _inventoryTransactions.Add(new InventoryTransaction
            {
                InventoryTransactionId = _inventoryTransactions.Count + 1,
                InventoryId = inventory.InventoryId,
                PoNumber = poNumber,
                Author = author,
                UnitPrice = price,
                QuantityBefore = inventory.Quantity,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                Activity = InventoryTransactionType.PurchaseInventory
            });
            return Task.CompletedTask;
        }
    }
}
