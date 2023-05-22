using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;
using IMS.Services.Products.Interfaces;

namespace IMS.Services.Products
{
    public class ViewProductsByNameService : IViewProductsByNameService
    {
        private readonly IProductRepository ProductRepository;
        public ViewProductsByNameService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task<IEnumerable<Product>> ExecuteAsync(string searchTerm)
        {
            return await ProductRepository.GetProductsByNameAsync(searchTerm);
        }
    }
}
