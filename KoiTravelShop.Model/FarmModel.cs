using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class FarmModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
