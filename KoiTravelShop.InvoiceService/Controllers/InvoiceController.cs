using KoiTravelShop.InvoiceService.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.InvoiceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController(InvoiceDbContext dbContext) : ControllerBase
    {
        [HttpGet] 
        public async Task<List<InvoiceModel>> GetAll ()
        {
            return await dbContext.Invoice.ToListAsync();
        }
    }
}
