using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
    public class Product_PriceLargerThanComponentsCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (ValidPrice(product))
                    return ValidationResult.Success;
            }
            return new ValidationResult($"Product price {product.Price} is less than total inventory cost {TotalInventoryCost(product)}");
        }
        private double TotalInventoryCost(Product product)
        {
            if (product == null || product.ProductInventories == null)
            {
                return 0;
            }
            
            return product.ProductInventories.Sum(productInventory =>
                productInventory.InventoryQuantity * productInventory.Inventory?.Price ?? 0);
        }
        private bool ValidPrice(Product product)
        {
            if (product.ProductInventories == null || product.ProductInventories.Count == 0) 
                return true;
            if (TotalInventoryCost(product) <= product.Price)
                return true;
            return false;
        }
    }
}
