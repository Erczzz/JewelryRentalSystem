﻿using JewelryRentalSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public IFormFile ProductImage { get; set; }
        public Product Product { get; set; }
    }
}