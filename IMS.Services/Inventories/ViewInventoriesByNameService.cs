namespace IMS.Services.Inventories
{
    public class ViewInventoriesByNameService
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