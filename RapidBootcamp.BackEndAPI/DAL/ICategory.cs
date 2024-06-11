using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface ICategory : ICrud<Category>
    {
        IEnumerable<Category> GetByCategoryName(string categoryName);
    }
}
