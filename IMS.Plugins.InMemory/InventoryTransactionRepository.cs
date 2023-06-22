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
        private List<Transaction> _transactions = new();

        public Task PurchaseAsync(Inventory inventory, 
                                  int quantity,
                                  double price,
                                  string poNumber,
                                  string author)
        {
            _transactions.Add(new Transaction
            {
                TransactionId = _transactions.Count + 1,
                TransactionType = TransactionType.Purchase,
                ItemType = ItemType.Inventory,
                QuantityBefore = inventory.Quantity,
                QuantityAfter = inventory.Quantity + quantity,
                PoNumber = poNumber,
                Author = author,
                TransactionDate = DateTime.Now,
                Price = price
            });
            return Task.CompletedTask;
        }
    }
}
