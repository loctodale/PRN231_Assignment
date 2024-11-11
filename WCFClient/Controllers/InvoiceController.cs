using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
namespace WCFClient.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceServiceClient client = new InvoiceServiceClient();
        public InvoiceController()
        {
            client = new InvoiceServiceClient();
        }
        public async Task<IActionResult> Index()
        {
            var invoices = await client.GetAllAsync();
            return View(invoices);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateInvoice(Invoice invoice)
        {
            var result = await client.CreateInvoiceAsync(invoice);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(Invoice invoice)
        {
            return View(invoice);
        }
        public async Task<IActionResult> UpdateInvoice(Invoice invoice)
        {
            var result = await client.UpdateInvoiceAsync(invoice);
            return RedirectToAction(nameof(Index));
        }
    }
}
