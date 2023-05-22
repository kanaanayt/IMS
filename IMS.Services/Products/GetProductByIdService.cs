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
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IProductRepository ProductRepository;

        public GetProductByIdService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task<Product> ExecuteAsync(int productId)
        {
            return await ProductRepository.GetProductByIdAsync(productId);
        }
    }
}
