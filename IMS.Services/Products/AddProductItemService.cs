using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;
using IMS.Services.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services.Products
{
    public class AddProductItemService : IAddProductItemService
    {
        private readonly IProductRepository ProductRepository;
        public AddProductItemService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await ProductRepository.AddProductItemAsync(product);
        }
    }
}
