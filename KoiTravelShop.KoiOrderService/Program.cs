using KoiTravelShop.KoiOrderService.Data;
using KoiTravelShop.KoiOrderService.Kafka;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<KoiOrderModel>();

// Add services to the container.

builder.Services.AddControllers().AddOData(
        option => option.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KoiOrderDbContext>(option => option.UseSqlServer("Server=(local); Database=KoiTravelShop_KoiOrder; Uid=sa; Pwd=12345; TrustServerCertificate=True"));
builder.Services.AddScoped<IKafkaProducer, KafkaProducer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseODataBatching();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
