using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KoiShopTravel.DeliveryDetailServicce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDetailController : ControllerBase
    {
       
        private static IList<DeliveryDetail> _delivery = new List<DeliveryDetail>
        {
            new DeliveryDetail { Id = 1, DeliveryName = "LocNgu", Address ="Vietnam" , Description = "giao ngay" , Price = 1500 },
            new DeliveryDetail { Id = 2, DeliveryName = "SonNgao", Address ="Vietnam" , Description = "giao ngay", Price = 800 },
            new DeliveryDetail { Id = 3, DeliveryName = "KhoiDu" ,Address ="Vietnam" , Description = "giao ngay", Price = 500 },
            new DeliveryDetail { Id = 4, DeliveryName = "VuongTen" ,Address ="Vietnam" , Description = "giao ngay", Price = 500 },

        };
     
        [HttpGet]
        public  List<DeliveryDetail> GetAll()
        {
            return  _delivery.ToList();
        } 
        
        [HttpPost] 
        public  IActionResult Post([FromBody] DeliveryDetail delivery)
        {
            if (_delivery.Any(p => p.Id == delivery.Id))
            {
                return BadRequest($"A product with ID {delivery.Id} already exists.");
            }

            if (delivery.Id == 0)
            {
                delivery.Id = _delivery.Any() ? _delivery.Max(p => p.Id) + 1 : 1;
            }

            _delivery.Add(delivery);

           return Ok("Thanh cong roi nha ban");
        }
    }
}
