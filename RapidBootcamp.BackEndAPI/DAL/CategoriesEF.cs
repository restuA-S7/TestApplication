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
            try
            {
                _appDBContext.Categories.Add(entity);
                _appDBContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var deleteCategory = GetById(id);
                _appDBContext.Categories.Remove(deleteCategory);
                _appDBContext.SaveChanges();
            }
            catch (Exception sqlEx)
            {

                throw new ArgumentException(sqlEx.Message);
            }
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
            var result = _appDBContext.Categories.Find(id);
            if(result == null)
            {
                throw new Exception("id not found");
            }
            return result;
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
