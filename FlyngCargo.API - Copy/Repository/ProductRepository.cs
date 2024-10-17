using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
          _context.Products.Add(product);
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(temp=>temp.ProductId==id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(temp => temp.ProductId == id);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            Product? matchingProduct = await _context.Products.FirstOrDefaultAsync(temp => temp.ProductId == product.ProductId);
            if (matchingProduct == null)
                return product;
            product.ProductName = matchingProduct.ProductName;
            product.Price= matchingProduct.Price;
            product.Description = matchingProduct.Description;
            product.StockQuantity= matchingProduct.StockQuantity;
            product.CreatedAt = matchingProduct.CreatedAt;
             await _context.SaveChangesAsync();
            return matchingProduct;

        }
    }
}
