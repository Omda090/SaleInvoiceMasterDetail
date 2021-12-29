using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleInvoiceMasterDetail.Models
{
    public class SaleInvoiceViewModel
    {
        public int InvId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvDate { get; set; }
        public string CustomerName { get; set; }
        public List<SaleInvoiceDetail> saleInvoiceDetails { get; set; }
    }
}
