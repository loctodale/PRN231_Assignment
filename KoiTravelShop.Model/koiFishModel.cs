using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class koiFishModel
    {
        public Guid Id { get; set; }

        public Guid? SizeId { get; set; }

        public int? Price { get; set; }

        public string Description { get; set; }
    }
}
