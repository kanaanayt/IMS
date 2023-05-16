using IMS.CoreBusiness;

namespace IMS.Services.Inventories.Interfaces
{
    public interface IViewInventoriesByNameService
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string invName = "");
    }
}