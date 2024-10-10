namespace KoiTravelShop.Model
{
    public class DeliveryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
