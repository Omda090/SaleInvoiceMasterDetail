using Microsoft.AspNetCore.Mvc;
using SaleInvoiceMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleInvoiceMasterDetail.Controllers
{
    public class SaleInvoiceController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}



        private readonly TestInvoiceDBContext _context = new TestInvoiceDBContext();
        public IActionResult Create()
        {
            SaleInvoiceViewModel viewModel = new SaleInvoiceViewModel();
            viewModel.saleInvoiceDetails = new List<SaleInvoiceDetail>();
            //for a while we are generating rows from server side but good practice //is to genrate it from client side(JQuery/JavaScript)
            SaleInvoiceDetail row1 = new SaleInvoiceDetail();
            SaleInvoiceDetail row2 = new SaleInvoiceDetail();
            SaleInvoiceDetail row3 = new SaleInvoiceDetail();
            viewModel.InvDate = DateTime.Now;
            viewModel.saleInvoiceDetails.Add(row1);
            viewModel.saleInvoiceDetails.Add(row2);
            viewModel.saleInvoiceDetails.Add(row3);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleInvoiceViewModel saleInvoiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var saleInVoiceMaster = new SaleInvoiceMaster()
                {
                    InvId = saleInvoiceViewModel.InvId,
                    InvDate = saleInvoiceViewModel.InvDate,
                    CustomerName = saleInvoiceViewModel.CustomerName
                };
                _context.SaleInvoiceMasters.Add(saleInVoiceMaster);
                await _context.SaveChangesAsync();
                foreach (var i in saleInvoiceViewModel.saleInvoiceDetails)
                {
                    var saleInvoiceDetail = new SaleInvoiceDetail()
                    {
                        InvId = saleInVoiceMaster.InvId,
                        ItemName = i.ItemName,
                        ItemQty = i.ItemQty
                    };
                    _context.SaleInvoiceDetails.Add(saleInvoiceDetail);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(saleInvoiceViewModel);
        }


    }
}
