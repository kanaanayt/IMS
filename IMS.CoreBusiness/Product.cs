﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage="Invalid Product Name")]
        public string ProductName { get; set; } = String.Empty;
        [Required]
        [Range(1, 1000, ErrorMessage="Invalid Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage="Invalid Price")]
        public double Price { get; set; }
    }
}