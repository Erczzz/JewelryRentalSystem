﻿using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int productId);
        Product GetProductByName(string name);
        Product DeleteProduct(int productId);
        bool Save();
    }
}
