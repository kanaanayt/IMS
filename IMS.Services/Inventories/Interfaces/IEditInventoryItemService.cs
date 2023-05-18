using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services.Inventories.Interfaces
{
    public interface IEditInventoryItemService
    {
        Task ExecuteAsync(Inventory inventory);
    }
}
