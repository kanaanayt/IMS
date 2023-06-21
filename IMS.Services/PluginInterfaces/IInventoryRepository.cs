using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string invName);
        Task AddInventoryItemAsync(Inventory inventory);
        Task EditInventoryItemAsync(Inventory inventory);
        Task<Inventory?> GetInventoryByIdAsync(int inventoryId);
    }
}
