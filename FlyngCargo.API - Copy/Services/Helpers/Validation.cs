using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class ValidationService : IValidationService
    {
        public void ValidateProductInput(string productName, string price, string description, string stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name is required.");
            }

            if (!decimal.TryParse(price, out decimal parsedPrice) || parsedPrice <= 0)
            {
                throw new ArgumentException("Price must be a positive number.");
            }

            if (!int.TryParse(stockQuantity, out int parsedStockQuantity) || parsedStockQuantity < 0)
            {
                throw new ArgumentException("Stock quantity must be a non-negative integer.");
            }

            if (description.Length > 200)
            {
                throw new ArgumentException("Description cannot exceed 200 characters.");
            }
        }
    }
}
