using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class KoiOrderModel
    {
        public Guid Id { get; set; }

        public Guid? InvoiceId { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
