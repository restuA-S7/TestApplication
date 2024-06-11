using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface ICustomer : ICrud<Customer>
    {
        IEnumerable<Customer> GetCustomersByNameOrCity(string customerName);
    }
}
