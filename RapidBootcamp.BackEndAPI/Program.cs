using Microsoft.EntityFrameworkCore;
using PraktekSendiri.ConsoleApp.DAL;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackEndAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//pakai swagger


//register ef
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//ini inectionnya gini aja
//DI
//builder.Services.AddScoped<ICategory, CategoriesDAL>();
//builder.Services.AddScoped<IProduct, ProducstDAL>();
//builder.Services.AddScoped<IOrderHeader, OrderHeadersDAL>();
//builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
//builder.Services.AddScoped<IWallet, WalletDAL>();

builder.Services.AddScoped<ICategory, CategoriesEF>();
builder.Services.AddScoped<IProduct, ProductsEF>();
builder.Services.AddScoped<IOrderHeader, OrderHeadersEF>();

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
