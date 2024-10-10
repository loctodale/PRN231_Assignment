using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class ServiceModel
    {
        public Guid Id { get; set; }

        public string? ServiceName { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}
