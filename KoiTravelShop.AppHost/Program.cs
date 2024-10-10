var builder = DistributedApplication.CreateBuilder(args);

var koiOrderApi = builder.AddProject<Projects.KoiTravelShop_KoiOrderService>("apiservice-product");
var invoiceApi = builder.AddProject<Projects.KoiTravelShop_InvoiceService>("apiservice-invoice");
var koiFishApi = builder.AddProject<Projects.KoiTravelShop_KoiFishService>("apiservice-fish");
var koiSizeApi = builder.AddProject<Projects.KoiTravelShop_KoiSizeService>("apiservice-size");


builder.AddProject<Projects.KoiTravelShop_Microservice>("webfrontend")
    .WithReference(koiOrderApi)
    .WithReference(invoiceApi)
    .WithReference(koiFishApi)
    .WithReference(koiSizeApi);

builder.Build().Run();
