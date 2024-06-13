// See https://aka.ms/new-console-template for more information
using RapidBootcamp.ReverseEf.DataBaseCF;
using RapidBootcamp.ReverseEf.Models;

Console.WriteLine("migrasi data dati db 1 ke db 2");

var db1 = new RapidDbContext();
var db2 = new RapidDbCFContext();

//var db1Categories = db1.Categories.ToList();

//List<RapidBootcamp.ReverseEf.DataBaseCF.Category> listCategory = new List<RapidBootcamp.ReverseEf.DataBaseCF.Category>();
//foreach (var item in db1Categories)
//{
//    listCategory.Add(new RapidBootcamp.ReverseEf.DataBaseCF.Category
//    {
//        id jangan dimasukan karena kan itu auto increment jadi gak bisa dimasukin
//        CategoryName = item.CategoryName
//    });
//}

//db2.Categories.AddRange(listCategory);
//db2.SaveChanges();
//Console.WriteLine("migrasi dari db1 ke db2 selsai");

var db1Products = db1.Products.ToList();

List<RapidBootcamp.ReverseEf.DataBaseCF.Product> listProducts = new List<RapidBootcamp.ReverseEf.DataBaseCF.Product>();
foreach (var item in db1Products)
{
    listProducts.Add(new RapidBootcamp.ReverseEf.DataBaseCF.Product
    {
        ProductName = item.ProductName,
        CategoryId = item.CategoryId,
        Price = item.Price,
        Stock = item.Stock

    });
}

try
{
    db2.Products.AddRange(listProducts);
    db2.SaveChanges();
    Console.WriteLine("migrasi product dari db1 ke db2 selsai");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    //throw new Exception(ex.Message);
}

