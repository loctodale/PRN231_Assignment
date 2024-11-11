using KoiTravelShop.InvoiceService.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.InvoiceService.Controllers
{
    [Route("api/odata/[controller]")]
    [ApiController]
    public class InvoiceController(InvoiceDbContext dbContext) : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<List<InvoiceModel>> GetAll ()
        {
            return await dbContext.Invoice.ToListAsync();
        }
    }
}
