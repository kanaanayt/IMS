﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.Services.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
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
            {
                return await Task.FromResult(_products);
            }

            return _products.Where(prod =>
                prod.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await Task.FromResult(_products.Single(prod => prod.ProductId == productId));
        }
        public async Task EditProductItemAsync(Product product)
        {
            foreach (var prod in _products)
            {
                if (prod.ProductId != product.ProductId &&
                    prod.ProductName.Equals(product.ProductName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            var editProduct = await GetProductByIdAsync(product.ProductId);
            if (editProduct != null)
            {
                editProduct.ProductName = product.ProductName;
                editProduct.Quantity = product.Quantity;
                editProduct.Price = product.Price;
            }
            return;
        }
        public Task AddProductItemAsync(Product product)
        {
            if (_products.Any(prod =>
                prod.ProductName.Equals(product.ProductName,
                StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            product.ProductId = _products.Count() + 1;
            _products.Add(product);

            return Task.CompletedTask;
        }
    }
}
