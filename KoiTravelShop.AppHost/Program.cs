var builder = DistributedApplication.CreateBuilder(args);

var koiOrderApi = builder.AddProject<Projects.KoiTravelShop_KoiOrderService>("apiservice-product");
var invoiceApi = builder.AddProject<Projects.KoiTravelShop_InvoiceService>("apiservice-invoice");


builder.AddProject<Projects.KoiTravelShop_Microservice>("webfrontend")
    .WithReference(koiOrderApi)
    .WithReference(invoiceApi);

builder.Build().Run();
