var builder = DistributedApplication.CreateBuilder(args);

var koiOrderApi = builder.AddProject<Projects.KoiTravelShop_KoiOrderService>("apiservice-product");
var invoiceApi = builder.AddProject<Projects.KoiTravelShop_InvoiceService>("apiservice-invoice");
var koiFishApi = builder.AddProject<Projects.KoiTravelShop_KoiFishService>("apiservice-fish");
var koiSizeApi = builder.AddProject<Projects.KoiTravelShop_KoiSizeService>("apiservice-size");
var deliveryApi = builder.AddProject<Projects.KoiTravelShop_DeliveryService>("apiservice-delivery");
var deliverydetailApi = builder.AddProject<Projects.KoiShopTravel_DeliveryDetailServicce>("apiservice-deliverydetail");
var serviceApi = builder.AddProject<Projects.KoiTravelShop_ServiceService>("apiservice-service");
var bookingRequestApi = builder.AddProject<Projects.KoiTravelShop_BookingRequest>("apiservice-bookingrequest");


builder.AddProject<Projects.KoiTravelShop_Microservice>("webfrontend")
    .WithReference(koiOrderApi)
    .WithReference(invoiceApi)
    .WithReference(koiFishApi)
    .WithReference(koiSizeApi)
    .WithReference(invoiceApi)
    .WithReference(deliveryApi)
    .WithReference(deliverydetailApi)
    .WithReference(serviceApi)
    .WithReference(bookingRequestApi);


builder.Build().Run();
