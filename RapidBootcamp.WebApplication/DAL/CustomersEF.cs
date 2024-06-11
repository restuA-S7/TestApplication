using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersEF : ICustomer
    {
        private readonly AppDbContext _dbContext;
        public CustomersEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer Add(Customer entity)
        {
            try
            {
                _dbContext.Customers.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var deleteCustomer = GetById(id);
                if (deleteCustomer != null)
                {
                    _dbContext.Customers.Remove(deleteCustomer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Customer not Found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var results = _dbContext.Customers.ToList();
            return results;
        }

        public Customer GetById(int id)
        {
            var result = _dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Customer Id Not Found");
            }
            return result;
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string keyword)
        {
            var results = _dbContext.Customers.Where(c => c.CustomerName.Contains(keyword) || c.City.Contains(keyword)).ToList();
            return results;
        }

        public Customer Update(Customer entity)
        {
            try
            {
                var updateCustomer = GetById(entity.CustomerId);
                if (updateCustomer != null)
                {
                    updateCustomer.CustomerName = entity.CustomerName;
                    updateCustomer.Address = entity.Address;
                    updateCustomer.City = entity.City;
                    updateCustomer.Email = entity.Email;
                    updateCustomer.PhoneNumber = entity.PhoneNumber;

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Cusomer Not found");
                }
                return updateCustomer;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
