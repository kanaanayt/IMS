﻿using IMS.CoreBusiness;
using IMS.Services.Activities.Interfaces;
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
        private readonly IInventoryTransactionRepository InventoryTransactionRepository;

        public PurchaseInventoryService(IInventoryRepository InventoryRepository,
                                        IInventoryTransactionRepository InventoryTransactionRepository)
        {
            this.InventoryRepository = InventoryRepository;
            this.InventoryTransactionRepository = InventoryTransactionRepository;
        }

        public async Task ExecuteAsync(Inventory inventory, int purchaseQuantity, string author, string poNumber)
        {
            await InventoryTransactionRepository.PurchaseAsync(
                inventory, purchaseQuantity, inventory.Price, poNumber, author);

            inventory.Quantity += purchaseQuantity;
            await InventoryRepository.EditInventoryItemAsync(inventory);
        }
    }
}
