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
    public class GetInventoryByIdService : IGetInventoryByIdService
    { 
        private readonly IInventoryRepository InventoryRepository;
        public GetInventoryByIdService(IInventoryRepository InventoryRepository)
        {
            this.InventoryRepository = InventoryRepository;
        }
        public async Task<Inventory> ExecuteAsync(int inventoryId)
        {
            return await InventoryRepository.GetInventoryByIdAsync(inventoryId);
        }
    }

}
