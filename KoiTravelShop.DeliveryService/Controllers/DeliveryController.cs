using KoiTravelShop.Model;
using Microsoft.AspNetCore.Mvc;



namespace KoiTravelShop.DeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private static IList<DeliveryModel> _delivery = new List<DeliveryModel>
        {
            new DeliveryModel { Id = Guid.NewGuid(), Name = "Laptop", Location ="Vietnam" , Description = "giao ngay" , Price = 1500 },
            new DeliveryModel { Id = Guid.NewGuid(), Name = "Smartphone", Location ="Vietnam" , Description = "giao ngay", Price = 800 },
            new DeliveryModel { Id = Guid.NewGuid(), Name = "Tablet" ,Location ="Vietnam" , Description = "giao ngay", Price = 500 },

        };

        [HttpGet]
        public List<DeliveryModel> Get()
        {
            var result =  _delivery.ToList();
            return result;
        }

        // GET api/delivery/5
        [HttpGet("{key}")]
        public DeliveryModel Get(Guid key)
        {
            var delivery = _delivery.FirstOrDefault(p => p.Id == key);
            return delivery;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DeliveryModel delivery)
        {

            if (_delivery.Any(p => p.Id == delivery.Id))
            {
                return BadRequest($"A product with ID {delivery.Id} already exists.");
            }

            if (delivery.Id == Guid.Empty)
            {
                delivery.Id = Guid.NewGuid();
            }
            _delivery.Add(delivery);

           return Ok("Thanh cong roi ban");
        }
      //  [HttpPut]
        // PUT: odata/Deliveries(1)
     /*   public IActionResult Put( int key, [FromBody] DeliveryModel update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = _delivery.FirstOrDefault(p => p.Id == key);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = update.Name;
            existing.Price = update.Price;
            // Cập nhật các thuộc tính khác nếu cần

            return Ok(existing);
        }*/

        
    }
}
