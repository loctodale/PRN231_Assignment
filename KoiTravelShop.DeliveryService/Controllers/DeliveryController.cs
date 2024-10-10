using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;

namespace KoiTravelShop.DeliveryService.Controllers
{
    public class DeliveryController : ODataController
    {
        private static IList<Delivery> _delivery = new List<Delivery>
        {
            new Delivery { Id = 1, Name = "Laptop", Location ="Vietnam" , Description = "giao ngay" , Price = 1500 },
            new Delivery { Id = 2, Name = "Smartphone", Location ="Vietnam" , Description = "giao ngay", Price = 800 },
            new Delivery { Id = 3, Name = "Tablet" ,Location ="Vietnam" , Description = "giao ngay", Price = 500 },

        };


        // GET: odata/Deliveries
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_delivery.AsQueryable());
        }

        // GET: odata/Deliveries(1)
        [EnableQuery]
        public IActionResult Get(int key)
        {
            var delivery = _delivery.FirstOrDefault(p => p.Id == key);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        // POST: odata/Deliveries
        public IActionResult Post([FromBody] Delivery delivery)
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

            return Created(delivery);
        }

        // PUT: odata/Deliveries(1)
        public IActionResult Put([FromODataUri] int key, [FromBody] Delivery update)
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

            return Updated(existing);
        }

        
    }
}
