using Entities;
using Services.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDTO productDTO);               
        Task DeleteProductAsync(int id);                          
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();      
        Task<ProductDTO> GetProductByIdAsync(int id);            
        Task UpdateProductAsync(ProductDTO productDTO);
      

    }
}
