//See https://aka.ms/new-console-template for more information
using CsvHelper;
using DataBase2 = RapidBootcamp.ReverseEf.DataBaseCF;
using DataBase1 = RapidBootcamp.ReverseEf.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using RapidBootcamp.ReverseEf.Models;
using System.Text;

//Console.WriteLine("migrasi data dati db 1 ke db 2");

//var db1 = new RapidDbContext();
//var db2 = new RapidDbCFContext();

//karena di atas ada using pakai alias maka bawahnya
var db1 = new DataBase1.RapidDbContext();
var db2 = new DataBase2.RapidDbCFContext();


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

//var db1Products = db1.Products.ToList();

//List<RapidBootcamp.ReverseEf.DataBaseCF.Product> listProducts = new List<RapidBootcamp.ReverseEf.DataBaseCF.Product>();
//foreach (var item in db1Products)
//{
//    listProducts.Add(new RapidBootcamp.ReverseEf.DataBaseCF.Product
//    {
//        ProductName = item.ProductName,
//        CategoryId = item.CategoryId,
//        Price = item.Price,
//        Stock = item.Stock

//    });
//}

//try
//{
//    db2.Products.AddRange(listProducts);
//    db2.SaveChanges();
//    Console.WriteLine("migrasi product dari db1 ke db2 selsai");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//    throw new Exception(ex.Message);
//}

//baca dari csv

//using (var reader = new StreamReader("C:\\Users\\NENDENPRA\\Downloads\\Categories.csv"))
//{
//    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//    {
//        var records = csv.GetRecords<RapidBootcamp.ReverseEf.DataBaseCF.Category>();
//        foreach (var record in records)
//        {
//            Console.WriteLine($"{record.CategoryId} - {record.CategoryName}");
//            db2.Categories.Add(record);
//        }
//        db2.SaveChanges();
//    }
//}

//ambil data dari api

//var httClient = new HttpClient();

//try
//{
//    var respone = await httClient.GetAsync("http://localhost:5102/api/Categories");
//    if (respone.IsSuccessStatusCode) //IsSuccessStatusCode ini kalau sukses 200
//    {
//        var data = await respone.Content.ReadAsStringAsync(); //ini data yang dibaca akan dijadikan string
//        tangkep nanti masukan ke list
//        dari string itu jadikan ke json Deserialize
//        var categories = JsonSerializer.Deserialize<List<RapidBootcamp.ReverseEf.DataBaseCF.Category>>(data);
//        foreach (var item in categories)
//        {
//            Console.WriteLine($"{item.CategoryId}-{item.CategoryName}");
//        }
//        db2.Categories.AddRange(categories);
//        db2.SaveChanges();
//        Console.WriteLine("Migrasi data berhasilll");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

//ambil sesuaikan by id
//var httClient = new HttpClient();

//try
//{
//    Console.Write("Masukan ID Product :");
//    var id = Convert.ToInt32(Console.ReadLine());
//    var response = await httClient.GetAsync($"http://localhost:5102/api/Products/{id}");
//    if (response.IsSuccessStatusCode)
//    {
//        var data = await response.Content.ReadAsStringAsync();
//        DataBase1.Product product = JsonSerializer.Deserialize<DataBase1.Product>(data);
//        Console.WriteLine($"{product.ProductId} - {product.ProductName} - {product.Price} - {product.Category.CategoryName}");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.InnerException.Message);
//}

//import ke tabel dari csv
//var httClient = new HttpClient();
//using (var reader = new StreamReader("C:\\Users\\NENDENPRA\\Downloads\\Categories.csv"))
//{
//    List<DataBase1.Category> categries = new List<DataBase1.Category>(); gak paki ini karena input data satu aja
//    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//    {
//        var records = csv.GetRecords<DataBase1.Category>();
//        foreach (var item in records)
//        {
//            var newCategory = JsonSerializer.Serialize<DataBase1.Category>(item);
//            var content = new StringContent(newCategory, Encoding.UTF8, "application/json");
//            var response = await httClient.PostAsync("http://localhost:5102/api/Categories", content);
//            if (response.IsSuccessStatusCode)
//            {
//                Console.WriteLine($"Data Category {item.CategoryName} berhasil di insert");
//            }
//            else
//            {
//                Console.WriteLine($"Data Category {item.CategoryName} gagal di insert");
//            }
//        }
//    }
//}
var httClient = new HttpClient();

//update jadi dari satu db disesuaikan terus di ganti 
//db 2 ngepasin terus gantiisi db1
//var db2Product = db2.Products.ToList();
//foreach (var item in db2Product)
//{
//    try
//    {
//        Console.WriteLine($"{item.ProductName}-{item.ProductId}-{item.Stock}");
//        var db1Product = new DataBase1.Product
//        {
//            ProductId = item.ProductId,
//            CategoryId = item.CategoryId,
//            ProductName = item.ProductName,
//            Stock = item.Stock,
//            Price = item.Price,
//        };
//        var serializeProduct = JsonSerializer.Serialize<DataBase1.Product>(db1Product);
//        var content = new StringContent(serializeProduct, Encoding.UTF8, "application/json"); //Encoding.UTF8 format pengiriman yang ke http
//        var response = await httClient.PutAsync($"http://localhost:5102/api/Products/{item.ProductId}", content);
//        if (response.IsSuccessStatusCode)
//        {
//            Console.WriteLine($"Data Product {item.ProductName} berhsil di update");
//        }
//        else
//        {
//            Console.WriteLine($"Data Product {item.ProductName} gagal di update");
//        }
//    }
//    catch (Exception ex)
//    {

//        Console.WriteLine(ex.InnerException.Message);
//    }

//}

//delete
using (var reader = new StreamReader("C:\\Users\\NENDENPRA\\Downloads\\Categories.csv"))
{
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<DataBase1.Category>();
        foreach (var item in records)
        {
            var response = await httClient.DeleteAsync($"http://localhost:5102/api/Categories/{item.CategoryId}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Data Category {item.CategoryName} berhasil di delete");
            }
            else
            {
                Console.WriteLine($"Data Category {item.CategoryName} gagal di delete");
            }
        }
    }
}


