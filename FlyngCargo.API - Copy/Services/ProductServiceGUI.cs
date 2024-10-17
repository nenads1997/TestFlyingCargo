using Newtonsoft.Json;
using Services.ServiceContracts;
using Services.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServiceGUI:IProductServiceGUI
    {
        private readonly HttpClient _httpClient;

        public ProductServiceGUI(HttpClient httpClient)
        {
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            //_httpClient = new HttpClient(handler);
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:44380/api/Products");
            return JsonConvert.DeserializeObject<List<ProductDTO>>(response);
        }

        public async Task AddProductAsync(ProductDTO productRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44380/api/Products", productRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(ProductDTO productRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44380/api/products/{productRequest.ProductId}", productRequest);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44380/api/Products/{productId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
