using IMS.CoreBusiness;
using IMS.Services.Inventories.Interfaces;
using IMS.Services.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services.Inventories
{
    public class AddInventoryItemService : IAddInventoryItemService
    {
        private readonly IInventoryRepository inventoryRepository;
        public AddInventoryItemService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventoryItem)
        {
            await inventoryRepository.AddInventoryItemAsync(inventoryItem);
        }
    }
}
