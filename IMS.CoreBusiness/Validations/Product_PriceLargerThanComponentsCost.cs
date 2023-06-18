﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
    public class Product_PriceLargerThanComponentsCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;

            if (product != null)
            {
                if (!ValidPrice(product))
                    return new ValidationResult($"" +
                        $"Product price {product.Price.ToString("c")} " +
                        $"is less than total inventories cost {TotalInventoriesCost(product).ToString("c")}", 
                        new List<string>
                        {
                            validationContext.MemberName
                        }
                    );

                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }

        private double TotalInventoriesCost(Product product)
        {
            if (product == null || product.ProductInventories == null)
                return 0;
            
            return product.ProductInventories.Sum(productInventory =>
                productInventory.InventoryQuantity * productInventory.Inventory?.Price ?? 0);
        }

        private bool ValidPrice(Product product)
        {
            if (product.ProductInventories == null || product.ProductInventories.Count == 0) 
                return true;
            if (TotalInventoriesCost(product) > product.Price)
                return false;

            return false;
        }
    }
}
