using IMS.CoreBusiness;

namespace IMS.Services.Inventories.Interfaces
{
    public interface IAddInventoryItemService
    {
        Task ExecuteAsync(Inventory inventoryItem);
    }
}