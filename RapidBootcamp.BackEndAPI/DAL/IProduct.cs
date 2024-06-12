using RapidBootcamp.BackEndAPI.DAL;
using RapidBootcamp.BackEndAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface IProduct : ICrud<Product>
    {
        IEnumerable<Product> GetByCategory(int categoryId);
        IEnumerable<Product> GetByProductName(string productName);
        IEnumerable<Product> GetByProductWithCategory();
        int CheckProductStock(int productId);
    }
}
