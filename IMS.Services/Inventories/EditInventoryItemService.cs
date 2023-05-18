using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.Services.Inventories.Interfaces;
using IMS.Services.PluginInterfaces;

namespace IMS.Services.Inventories
{
    public class EditInventoryItemService : IEditInventoryItemService
    {
        private readonly IInventoryRepository InventoryRepository;
        public EditInventoryItemService(IInventoryRepository InventoryRepository)
        {
            this.InventoryRepository = InventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await InventoryRepository.EditInventoryItemAsync(inventory);
        }
    }
}
