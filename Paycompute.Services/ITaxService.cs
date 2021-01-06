using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services
{
    interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
