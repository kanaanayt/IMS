﻿using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new()
            {
                new Product {

                    ProductId = 1,
                    ProductName = "Bike",
                    Quantity = 10,
                    Price = 150

                }, new Product {

                    ProductId = 2,
                    ProductName = "Car",
                    Quantity = 5,
                    Price = 25000
                }
            };
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                return await Task.FromResult(_products);

            var products = _products.Where(prod =>
                prod.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(products);
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await Task.FromResult(_products.FirstOrDefault(prod => prod.ProductId == productId));
        }

        public async Task EditProductItemAsync(Product product)
        {
            if (await ExistsAsync(product))
                return;

            var match = await GetProductByIdAsync(product.ProductId);
            
            if (match != null)
            {
                match.ProductName = product.ProductName;
                match.Quantity = product.Quantity;
                match.Price = product.Price;
                match.ProductInventories = product.ProductInventories;
            }

            return;
        }

        public async Task<bool> ExistsAsync(Product product)
        {
            return await Task.FromResult(_products.Any(prod =>
                prod.ProductId != product.ProductId &&
                prod.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)));
        }

        public Task AddProductItemAsync(Product product)
        {
            if (_products.Any(prod =>
                prod.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            product.ProductId = _products.Count + 1;
            _products.Add(product);

            return Task.CompletedTask;
        }
    }
}
