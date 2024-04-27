﻿using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductServices
    {
        Task<int> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
    }
}