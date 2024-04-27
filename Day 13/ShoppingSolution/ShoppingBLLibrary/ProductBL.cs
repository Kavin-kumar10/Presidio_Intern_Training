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


        public async Task<int> AddProduct(Product product)
        {
            var result =await _productRepository.Add(product);
            if (result != null) return result.Id;
            throw new DuplicateItemFoundException();
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _productRepository.GetByKey(id);
            if ( result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _productRepository.GetAll();
            if(result != null) return result.ToList();
            throw new ItemNotFoundException();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _productRepository.Update(product);
            if (result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var result = await _productRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new ItemNotFoundException();
        }
    }
}
