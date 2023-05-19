using IMS.CoreBusiness;

namespace IMS.Services.Inventories.Interfaces
{
    public interface IGetInventoryByIdService
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}