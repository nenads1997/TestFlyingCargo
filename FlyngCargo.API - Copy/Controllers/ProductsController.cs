using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;
using Services;
using Services.ServiceContracts;
using Services.ServiceContracts.DTO;

namespace FlyngCargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductDTO productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest("Product can't be null!"); 
            }

          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            productRequest.ProductId = product.ProductId;
            return CreatedAtAction(nameof(GetProductById), new { id = productRequest.ProductId }, productRequest); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
           
           IEnumerable<Product> products= await _unitOfWork.Products.GetAllProductsAsync();
           IEnumerable<ProductDTO> productResponse= _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productResponse); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            Product? product= await _unitOfWork.Products.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found!");
            }
            ProductDTO productResponse = _mapper.Map<ProductDTO>(product);

            return Ok(productResponse); 
        }
      


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDTO productRequest)
        {
            if (productRequest == null || productRequest.ProductId != id)
            {
                return BadRequest("Product not found/cant be null!");
            }
            var existingProduct = await _unitOfWork.Products.GetProductByIdAsync(id);

         
            if (existingProduct == null)
            {
                return NotFound("Product not found!");
            }
            existingProduct.ProductName = productRequest.ProductName;
            existingProduct.Price = productRequest.Price;
            existingProduct.Description = productRequest.Description;
            existingProduct.StockQuantity = productRequest.StockQuantity;

            await _unitOfWork.Products.UpdateProductAsync(existingProduct);
            await _unitOfWork.CompleteAsync();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _unitOfWork.Products.DeleteProductAsync(id);
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Product not found!"); 
            }
        }
    }
}
