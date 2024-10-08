using KoiTravelShop.KoiOrderService.Data;
using KoiTravelShop.KoiOrderService.Kafka;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
