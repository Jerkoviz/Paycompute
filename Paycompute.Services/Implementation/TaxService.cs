using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal tax;
        private decimal taxRate;
        public decimal TaxAmount(decimal totalAmount)
        {
            if ( totalAmount <= 1042)
            {
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 1042 && totalAmount <= 3125)
            {
                taxRate = 0.20m;
                tax = (1042 * .0m) + ((totalAmount - 1042) * taxRate);
            }
            else if ( totalAmount > 3125 && totalAmount <= 12500)
            {
                taxRate = 0.40m;
                tax = (1042 * .0m) + ((3125 - 1042) * taxRate) + ((totalAmount - 3125) * taxRate);
            }
            else if (totalAmount > 12500)
            {
                taxRate = .45m;
                tax = (1042 * .0m) + ((3125 - 1042) * taxRate) + ((12500 - 3125) * taxRate) + ((totalAmount - 12500) * taxRate);
            }
            return tax;
        }
    }
}
