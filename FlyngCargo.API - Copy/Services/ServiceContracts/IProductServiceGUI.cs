using Services.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public interface IProductServiceGUI
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task AddProductAsync(ProductDTO productRequest);
        Task UpdateProductAsync(ProductDTO productRequest);
        Task DeleteProductAsync(int productId);
    }
}
