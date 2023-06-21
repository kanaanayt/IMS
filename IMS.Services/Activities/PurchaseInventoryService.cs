using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services.Activities
{
    public class PurchaseInventoryService : IPurchaseInventoryService
    {
        private readonly IInventoryRepository InventoryRepository;
        private readonly ITransactionRepository TransactionRepository;

        public PurchaseInventoryService(IInventoryRepository InventoryRepository,
                                        ITransactionRepository TransactionRepository)
        {
            this.InventoryRepository = InventoryRepository;
            this.TransactionRepository = TransactionRepository;
        }

        public async Task ExecuteAsync(Inventory inventory, int purchaseQuantity,
                                       string author, string poNumber)
        {
            await InventoryRepository.PurchaseInventoryAsync(inventory, purchaseQuantity,
                                                             author, poNumber);
            await TransactionRepository.AddTransactionAsync(Transaction.TransactionType.Purchase,
                                                       Transaction.ItemType.Inventory,
                                                       purchaseQuantity,
                                                       poNumber,
                                                       author);
        }
    }
}
