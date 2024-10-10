var builder = DistributedApplication.CreateBuilder(args);

var koiOrderApi = builder.AddProject<Projects.KoiTravelShop_KoiOrderService>("apiservice-product");
var invoiceApi = builder.AddProject<Projects.KoiTravelShop_InvoiceService>("apiservice-invoice");
var travelApi = builder.AddProject<Projects.KoiTravelShop_TravelService>("apiservice-travel");
var farmApi = builder.AddProject<Projects.KoiTravelShop_FarmService>("apiservice-farm");

builder.AddProject<Projects.KoiTravelShop_Microservice>("webfrontend")
    .WithReference(travelApi)
    .WithReference(farmApi)
    .WithReference(koiOrderApi)
    .WithReference(invoiceApi);

builder.Build().Run();
