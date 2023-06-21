using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository, IInventoryTransactionRepository
    {
        private List<Transaction> _transactions = new();

        public Task PurchaseAsync(Inventory inventory,
                                        string poNumber,
                                        string author,
                                        int quantity)
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
                TransactionDate = DateTime.Now
            });
            return Task.CompletedTask;
        }
    }
}
