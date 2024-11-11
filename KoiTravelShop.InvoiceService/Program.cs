using KoiTravelShop.InvoiceService.Data;
using KoiTravelShop.InvoiceService.Kafka;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<InvoiceModel>();
// Add services to the container.
builder.Services.AddControllers().AddOData(
        option => option.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InvoiceDbContext>(option => option.UseSqlServer("Server=(local); Database=KoiTravelShop_Invoice; Uid=sa; Pwd=12345; TrustServerCertificate=True"));
builder.Services.AddHostedService<KafkaConsumer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseODataBatching();
app.UseAuthorization();

app.MapControllers();

app.Run();
