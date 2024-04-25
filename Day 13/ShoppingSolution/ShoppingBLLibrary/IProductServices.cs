using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductServices
    {
        int AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        Product UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
