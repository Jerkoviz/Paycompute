using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paycompute.Entity
{
    public class TaxYear
    {          
        public int TaxYearId { get; set; }
        
        public string YearOfTax { get; set; }
    }
}
