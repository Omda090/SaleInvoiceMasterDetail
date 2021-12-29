using System;
using System.Collections.Generic;

#nullable disable

namespace SaleInvoiceMasterDetail.Models
{
    public partial class SaleInvoiceMaster
    {
        public SaleInvoiceMaster()
        {
            SaleInvoiceDetails = new HashSet<SaleInvoiceDetail>();
        }

        public int InvId { get; set; }
        public DateTime InvDate { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
    }
}
