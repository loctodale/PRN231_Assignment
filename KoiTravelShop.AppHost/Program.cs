var builder = DistributedApplication.CreateBuilder(args);

var koiOrderApi = builder.AddProject<Projects.KoiTravelShop_KoiOrderService>("apiservice-product");
var invoiceApi = builder.AddProject<Projects.KoiTravelShop_InvoiceService>("apiservice-invoice");
var deliveryApi = builder.AddProject<Projects.KoiTravelShop_DeliveryService>("apiservice-delivery");
var deliverydetailApi = builder.AddProject<Projects.KoiShopTravel_DeliveryDetailServicce>("apiservice-deliverydetail");


builder.AddProject<Projects.KoiTravelShop_Microservice>("webfrontend")
    .WithReference(koiOrderApi)
    .WithReference(invoiceApi)
    .WithReference(deliveryApi)
    .WithReference(deliverydetailApi);

builder.Build().Run();
