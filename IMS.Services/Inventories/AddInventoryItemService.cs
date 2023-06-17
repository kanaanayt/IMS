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
        private readonly IInventoryRepository InventoryRepository;
        public AddInventoryItemService(IInventoryRepository InventoryRepository)
        {
            this.InventoryRepository = InventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventoryItem)
        {
            await InventoryRepository.AddInventoryItemAsync(inventoryItem);
        }
    }
}
