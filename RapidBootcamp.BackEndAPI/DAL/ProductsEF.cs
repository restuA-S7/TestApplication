using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class ProductsEF : IProduct
    {
        private readonly AppDBContext _appDbContext;
        public ProductsEF(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public int CheckProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var result = _appDbContext.Products.OrderBy(p => p.ProductName).ToList();
            return result;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            var product = _appDbContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                throw new Exception("product not found");
            }
            return product;
        }

        public IEnumerable<Product> GetByProductName(string productName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByProductWithCategory()
        {
            var result = _appDbContext.Products.Include(p => p.Category)
                .OrderBy(p => p.ProductName).ToList();
            return result;
        }

        public Product Update(Product entity)
        {
            try
            {
                var updateProduct = GetById(entity.ProductId);
                updateProduct.ProductName = entity.ProductName;
                updateProduct.CategoryId = entity.CategoryId;
                updateProduct.Stock = entity.Stock;
                updateProduct.Price = entity.Price;
                _appDbContext.SaveChanges();
                return updateProduct;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
