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
        private readonly IInventoryRepository InventoryRepository;

        public ViewInventoriesByNameService(IInventoryRepository InventoryRepository)
        {
            this.InventoryRepository = InventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string invName = "")
        {
            return await InventoryRepository.GetInventoriesByNameAsync(invName);
        }
    }
}