using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);


//registrasi db context untuk entitiy framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//MENAMBAHKAN MODUL MVC
builder.Services.AddControllersWithViews();
//kalau di atas cuman pakai add controler itu jadinya nanti API

//tambahkan ef di sininya
//builder.Services.AddScoped<ICategory, CategoriesDAL>();
builder.Services.AddScoped<ICategory, CategoriesEF>();
builder.Services.AddScoped<ICustomer, CustomersEF>();
builder.Services.AddScoped<IProduct, ProductsEF>();


var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}");
//app.MapGet("/", () => "Hello Bandung!");

app.Run();
