using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class CategoriesEF : ICategory
    {
        private readonly AppDBContext _appDBContext;
        public CategoriesEF(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            var result = _appDBContext.Categories.OrderBy(c => c.CategoryName).ToList();
            return result;
        }

        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
