namespace KoiShopTravel.Model;

public class DeliveryDetailModel
{
    public int Id { get; set; }
    public string DeliveryName { get; set; }

    public string Address { get; set; }

    public string Description { get; set; }
    public decimal Price { get; set; }
}
