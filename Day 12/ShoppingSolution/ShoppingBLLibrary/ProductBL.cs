using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductServices
    {
        readonly ProductRepository _productRepository;

        public ProductBL(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public int AddProduct(Product product)
        {
            return _productRepository.Add(product).Id; 
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetByKey(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
