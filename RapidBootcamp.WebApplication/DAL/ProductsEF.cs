using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class ProductsEF : IProduct
    {
        private readonly AppDbContext _dbContext;
        public ProductsEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _dbContext.Products.Include(P => P.Category).ToList();
            return results;
        }

        public Product GetById(int id)
        {
            var result = _dbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Product Not Found");
            }
            return result;
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
