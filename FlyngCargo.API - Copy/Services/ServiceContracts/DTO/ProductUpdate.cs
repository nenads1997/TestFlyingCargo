using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts.DTO
{
    public class ProductUpdate
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name can't be null")]
        public string ProductName { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative")]
        public int StockQuantity { get; set; }
    }
}
