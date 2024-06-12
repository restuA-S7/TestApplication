using PraktekSendiri.ConsoleApp.DAL;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackEndAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//pakai swagger

//ini inectionnya gini aja
//DI
builder.Services.AddScoped<ICategory, CategoriesDAL>();
builder.Services.AddScoped<IProduct, ProducstDAL>();
builder.Services.AddScoped<IOrderHeader, OrderHeadersDAL>();
builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
builder.Services.AddScoped<IWallet, WalletDAL>();

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
