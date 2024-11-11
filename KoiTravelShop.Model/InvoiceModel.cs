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
        public string? InvoiceNumber { get; set; } // Unique identifier for the invoice

        public DateTime? IssueDate { get; set; } // Date when the invoice was issued

        public DateTime? DueDate { get; set; } // Date when payment is due
        public decimal? TaxAmount { get; set; } // Tax amount applied to the invoice

        public decimal? DiscountAmount { get; set; } // Discount amount on the invoice

        public string? PaymentMethod { get; set; } // Method of payment (e.g., "Credit Card", "Bank Transfer")
    }
}
