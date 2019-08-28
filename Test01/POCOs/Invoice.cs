using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test01.POCOs
{
    public class Invoice
    {
        /// <summary>
        /// 
        /// </summary>
        public Invoice()
        {
            this.Lines = new List<InvoiceLine>();
        }

        public string InvoiceNumber { get; set; }

        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TaxableAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public IList<InvoiceLine> Lines { get; set; }
    }
}
