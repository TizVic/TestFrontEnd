using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test01.POCOs
{
    public class InvoiceLine
    {
        public string ItemId { get; set; }

        public string ItemDescription { get; set; }

        public int Quantity { get; set; }

        public decimal LineAmount { get; set; }

        public decimal DiscountRate { get; set; }

        public decimal VatRate { get; set; }
    }
}
