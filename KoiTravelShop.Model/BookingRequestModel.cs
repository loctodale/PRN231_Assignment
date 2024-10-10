using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiTravelShop.Model
{
    public class BookingRequestModel
    {
        public Guid Id { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? TravelId { get; set; }

        public int? QuantityService { get; set; }

        public int? NumberOfPerson { get; set; }

        public BookingRequestStatus? Status { get; set; }
    }

    public enum BookingRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
