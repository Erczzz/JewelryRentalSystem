﻿using JewelryRentalSystemAPI.Models;

namespace JewelryRentalSystemAPI.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        ICollection<Product> GetProductByCategory(int categoryId);
        Category DeleteCategory(int categoryId);
        Category AddCategory(Category newCategory);
        Category UpdateCategory(int categoryId, Category updatedCategory);    

    }
}
