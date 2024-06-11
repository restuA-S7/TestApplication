using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesEF : ICategory
    {
        private readonly AppDbContext _dbContext;
        public CategoriesEF(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public Category Add(Category entity)
        {
            try
            {
                _dbContext.Categories.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public void Delete(int id)
        {
            try
            {
                var deleteCategory = GetById(id);
                if (deleteCategory != null)
                {
                    _dbContext.Categories.Remove(deleteCategory);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Categroy Not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }

        public IEnumerable<Category> GetAll()
        {
            var results = _dbContext.Categories.ToList();
            return results;
        }

        public Category GetById(int id)
        {
            var result = _dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();

            /*var result = (from c in _dbContext.Categories
                          where c.CategoryId == id
                          select c).FirstOrDefault();*/
            if (result == null)
            {
                throw new ArgumentException("Category not found");
            }
            return result;
        }

        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            //var results = _dbContext.Categories.Where(c => c.CategoryName.Contains(categoryName)).ToList();
            var results = (from c in _dbContext.Categories
                           where c.CategoryName.Contains(categoryName)
                           select c).ToList();
            return results;
        }

        public Category Update(Category entity)
        {
            try
            {
                var updateCategory = GetById(entity.CategoryId);
                if(updateCategory != null)
                {
                    updateCategory.CategoryName = entity.CategoryName;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Category Not Found");
                }
                return updateCategory;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
