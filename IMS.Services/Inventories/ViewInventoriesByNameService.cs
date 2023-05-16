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
    public class ViewInventoriesByNameService : IViewInventoriesByNameService
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string invName = "")
        {
            return await inventoryRepository.GetInventoriesByNameAsync(invName);
        }
    }
}