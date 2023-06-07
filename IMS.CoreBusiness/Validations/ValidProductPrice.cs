using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    //public class ValidProductPrice : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value)
    //    {
    //        int total = 0;
    //        foreach (var productInventory in ProductInventories)
    //        {
    //            total += productInventory.Inventory.Price * productInventory.InventoryQuantity;
    //        }
    //        if (Price < total)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        return new ValidationResult("does not compute");
    //    }
    //}
}
