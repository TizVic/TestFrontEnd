using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test01.POCOs;

namespace Test01.API
{
    [Route("api/data")]
    [ApiController]
    public class ApiDataController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("invoices")]
        public IActionResult GetInvoices()
        {
            IList<Invoice> invoices = this.CreateInvoices();

            IHeaderDictionary headers = Request.Headers;

            return new JsonResult(invoices);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("invoiceHeaders")]
        public IActionResult GetInvoiceHeaders()
        {
            IList<Invoice> invoices = this.CreateInvoiceHeaders();
            
            return new JsonResult(this.GetDataForDataTables<Invoice>(invoices));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost("createInvoice")]
        public IActionResult PostInvoice([FromForm] Invoice invoice)
        {
            if (invoice.CustomerName != null)
            {
                return Ok();
            }

            return StatusCode(400);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <returns></returns>
        public DataTablesContainerBean GetDataForDataTables<T>(IEnumerable<T> l)
        {
            DataTablesContainerBean bean = new DataTablesContainerBean
            {
                data = l ?? new List<T>()
            };

            return bean;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Invoice> CreateInvoices()
        {
            IList<Invoice> invoices = new List<Invoice>();

            Invoice i1 = new Invoice()
            {
                CustomerName = "Altromercato",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV01",
                TaxableAmount = 100,
                TotalAmount = 123
            };

            InvoiceLine l11 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Spaghetti di grano duro",
                ItemId = "0000007",
                LineAmount = 7.54M,
                Quantity = 10,
                VatRate = 4
            };

            InvoiceLine l12 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Spaghetti di quinoa",
                ItemId = "0000008",
                LineAmount = 9.00M,
                Quantity = 8,
                VatRate = 4
            };

            InvoiceLine l13 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Penne",
                ItemId = "0000010",
                LineAmount = 10.0M,
                Quantity = 5,
                VatRate = 4
            };

            i1.Lines.Add(l11);
            i1.Lines.Add(l12);
            i1.Lines.Add(l13);

            Invoice i2 = new Invoice()
            {
                CustomerName = "Inventa",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV02",
                TaxableAmount = 200,
                TotalAmount = 246
            };

            InvoiceLine l21 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Spaghetti di grano tenero",
                ItemId = "0000011",
                LineAmount = 5M,
                Quantity = 5,
                VatRate = 10
            };

            InvoiceLine l22 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Spaghetti di farro",
                ItemId = "0000012",
                LineAmount = 9.00M,
                Quantity = 8,
                VatRate = 4
            };

            i2.Lines.Add(l21);
            i2.Lines.Add(l22);

            Invoice i3 = new Invoice()
            {
                CustomerName = "Agrofer",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV03",
                TaxableAmount = 300,
                TotalAmount = 350
            };

            InvoiceLine l31 = new InvoiceLine()
            {
                DiscountRate = 0,
                ItemDescription = "Pizza margherita",
                ItemId = "0000012",
                LineAmount = 12M,
                Quantity = 2,
                VatRate = 10
            };

            i3.Lines.Add(l31);

            invoices.Add(i1);
            invoices.Add(i2);
            invoices.Add(i3);

            return invoices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Invoice> CreateInvoiceHeaders()
        {
            IList<Invoice> invoices = new List<Invoice>();

            Invoice i1 = new Invoice()
            {
                CustomerName = "Altromercato",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV01",
                TaxableAmount = 100,
                TotalAmount = 123
            };

            Invoice i2 = new Invoice()
            {
                CustomerName = "Inventa",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV02",
                TaxableAmount = 200,
                TotalAmount = 246
            };

            Invoice i3 = new Invoice()
            {
                CustomerName = "Agrofer",
                InvoiceDate = DateTime.Today,
                InvoiceNumber = "INV03",
                TaxableAmount = 300,
                TotalAmount = 350
            };

            invoices.Add(i1);
            invoices.Add(i2);
            invoices.Add(i3);

            return invoices;
        }
    }
}