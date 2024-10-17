using Services.ServiceContracts;
using Services.ServiceContracts.DTO;
using System.ComponentModel;

namespace FlyngCargo.API.ViewModel
{
    public class ProductViewModel
    {
        private readonly IProductService _productService;

        public BindingList<ProductDTO> Products { get; set; }

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            Products = new BindingList<ProductDTO>();
        }

        public async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            await _productService.AddProductAsync(productDTO);
            await LoadProductsAsync();
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            await _productService.UpdateProductAsync(productDTO);
            await LoadProductsAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            await LoadProductsAsync();
        }
    }
}
