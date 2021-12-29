using System;
using System.Collections.Generic;

#nullable disable

namespace SaleInvoiceMasterDetail.Models
{
    public partial class SaleInvoiceDetail
    {
        public int InvDetailId { get; set; }
        public int InvId { get; set; }
        public string ItemName { get; set; }
        public int ItemQty { get; set; }

        public virtual SaleInvoiceMaster Inv { get; set; }
    }
}
