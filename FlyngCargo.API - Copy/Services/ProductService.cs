using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Repository.RepositoryContract;
using Repository.UnitOfWork;
using Services.Helpers;
using Services.ServiceContracts;
using Services.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        public async Task AddProductAsync(ProductDTO productRequest)
        {
            if(productRequest==null)
            {
                throw new ArgumentNullException(nameof(productRequest));
            }
            ValidationHelper.ModelValidation(productRequest);
            var product = new Product
            {
                ProductName = productRequest.ProductName,
                Price = productRequest.Price,
                Description = productRequest.Description,
                StockQuantity = productRequest.StockQuantity,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.Products.AddProductAsync(product);
            await _unitOfWork.CompleteAsync(); 
           
            
        }
       
        public async Task DeleteProductAsync(int id)
        {
            var deleted = await _unitOfWork.Products.DeleteProductAsync(id); 
            if (!deleted)
            {
                throw new KeyNotFoundException("Product not found!"); 
            }
            await _unitOfWork.CompleteAsync();
        }

       
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllProductsAsync(); 
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

       

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            Product? product = await _unitOfWork.Products.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found!"); 
            }
            return _mapper.Map<ProductDTO>(product); 
        }

    
        public async Task UpdateProductAsync(ProductDTO productRequest)
        {
            Product? existingProduct = await _unitOfWork.Products.GetProductByIdAsync(productRequest.ProductId);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found!"); 
            }

            _mapper.Map(productRequest, existingProduct);

            await _unitOfWork.Products.UpdateProductAsync(existingProduct);
            await _unitOfWork.CompleteAsync();
        }
    }
}
