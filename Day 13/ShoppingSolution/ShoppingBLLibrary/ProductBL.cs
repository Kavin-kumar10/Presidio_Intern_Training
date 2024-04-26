using ExceptionHandling;
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
            var result = _productRepository.Add(product).Id;
            if (result != null) return result;
            throw new DuplicateItemFoundException();
        }

        public Product GetProductById(int id)
        {
            var result = _productRepository.GetByKey(id);
            if ( result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }

        public List<Product> GetAllProducts()
        {
            var result = _productRepository.GetAll().ToList();
            if(result != null) return result;
            throw new ItemNotFoundException();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _productRepository.Update(product);
            if (result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }

        public Product DeleteProduct(int id)
        {
            var result = _productRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }
    }
}
