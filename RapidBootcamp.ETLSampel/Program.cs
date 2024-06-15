using Microsoft.EntityFrameworkCore;
using RapidBootcamp.ETLSampel.RapidDb;
using RapidBootcamp.ETLSampel.RapidDw;


var db1 = new RapidDbContext();
var db2 = new RapidDwContext();


//var query = @"select p.ProductName, c.CategoryName, p.Price, p.Stock from Products p inner join Categories c on p.CategoryId = c.CategoryId";

//var db1ProductCategory = db1.Products.Include(p => p.Category).ToList();

//List<RapidBootcamp.ETLSampel.RapidDw.DimProduct> ListPerpindahan = new List<RapidBootcamp.ETLSampel.RapidDw.DimProduct>();
//foreach (var item in db1ProductCategory)
//{
//    ListPerpindahan.Add(new RapidBootcamp.ETLSampel.RapidDw.DimProduct
//    {
//        ProductName = item.ProductName,
//        CategoryName = item.Category.CategoryName,
//        Price = item.Price,
//        Stock = item.Stock
//    });
//}

//try
//{
//    db2.DimProducts.AddRange(ListPerpindahan);
//    db2.SaveChanges();
//    Console.WriteLine("perpindahan selesaii");
//}
//catch (Exception ex)
//{

//    throw new ArgumentException(ex.InnerException.Message);
//}

//var db1Wallet = db1.Wallets
//                            .Include(w => w.WalletType)
//                            .Include(w => w.Customer).ToList();

//List<RapidBootcamp.ETLSampel.RapidDw.DimWallet> ListPerpindahanWallet = new List<RapidBootcamp.ETLSampel.RapidDw.DimWallet>();
//foreach (var item in db1Wallet)
//{
//    ListPerpindahanWallet.Add(new RapidBootcamp.ETLSampel.RapidDw.DimWallet
//    {
//        WalletOriginalKey = item.WalletId,
//        CustomerName = item.Customer.CustomerName,
//        CustomerEmail = item.Customer.Email,
//        CustomerCity = item.Customer.City,
//        CustomerPhoneNumber = item.Customer.PhoneNumber,
//        WalletTypeName = item.WalletType.WalletName,
//        Saldo = item.Saldo
//    });
//}

//try
//{
//    db2.Database.ExecuteSqlRaw("TRUNCATE TABLE DimWallet");
//    db2.DimWallets.AddRange(ListPerpindahanWallet);
//    db2.SaveChanges();
//    Console.WriteLine("perpindahan selesaii");
//}
//catch (Exception ex)
//{

//    throw new ArgumentException(ex.InnerException.Message);
//}


var dbFactSales = db1.OrderDetails
                            .Include(od => od.OrderHeader)
                            .Include(od => od.Product).ToList();

List<RapidBootcamp.ETLSampel.RapidDw.FactSale> listFactSales = new List<RapidBootcamp.ETLSampel.RapidDw.FactSale>();
foreach (var item in dbFactSales)
{

    var productId = db2.DimProducts
        .FirstOrDefault(p => p.ProductId == item.ProductId).ProductId;

    var walletId = db2.DimWallets
        .FirstOrDefault(p => p.WalletOriginalKey == item.OrderHeader.WalletId).WalletId;

    listFactSales.Add(new RapidBootcamp.ETLSampel.RapidDw.FactSale
    {
        ProductId = productId,
        WalletId = walletId,
        OrderHeaderId = item.OrderHeaderId,
        OrderDetailOriginalId = item.OrderDetailId,
        Qty = item.Qty,
        Price = item.Price,
        TotalSales = item.Qty * item.Price
    });
}

try
{
    db2.Database.ExecuteSqlRaw("delete from Fact_Sales");
    db2.FactSales.AddRange(listFactSales);
    db2.SaveChanges();
    Console.WriteLine("perpindahan selesaii");
}
catch (Exception ex)
{

    throw new ArgumentException(ex.InnerException.Message);
}