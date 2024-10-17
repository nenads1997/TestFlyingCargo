using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public  interface IValidationService
    {
        void ValidateProductInput(string productName, string price, string description, string stockQuantity);
    }
}
