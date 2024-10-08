using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }

        public decimal? PaymentAmount { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
