using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersDAL : ICustomer
    {

        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private readonly IConfiguration _configuration;
        public CustomersDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = @"Server=.\;Database=RapidDb;Trusted_Connection=True;";
            _connection = new SqlConnection(_connectionString);
        }

        public string GetConStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public Customer Add(Customer entity)
        {
            //using (SqlConnection conn = new SqlConnection(GetConStr()))
            //{
            //    try
            //    {
            //        string query = @"INSERT INTO Customers(CustomerName, Address, Email, PhoneNumber) 
            //        VALUES(@CustomerName, @Address, @Email, @PhoneNumber); select @@identity";
            //        _command = new SqlCommand(query, conn);
            //        _command.Parameters.AddWithValue("@CustomerName", entity.CustomersName);
            //        _command.Parameters.AddWithValue("@Address", entity.Address);
            //        _command.Parameters.AddWithValue("@Email", entity.Email);
            //        _command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            //        conn.Open();
            //        entity.CustomersId = Convert.ToInt32(_command.ExecuteScalar());
            //        return entity;

            //        string query = @"INSERT INTO Customers(CustomersName,Address,City,Email, PhoneNumber) 
            //                    VALUES(@CustomersName,@Address,@City,@Email,@PhoneNumber );SELECT @@identity";
            //        var param = new { CustomersName = entity.CustomersName, Address = entity.Address, City = entity.City, Email = entity.Email, PhoneNumber = entity.PhoneNumber };
            //        int newId = conn.ExecuteScalar<int>(query, param);
            //        entity.CustomersId = newId;
            //        return entity;
            //    }
            //    catch (SqlException sqlEx)
            //    {

            //        throw new ArgumentException(sqlEx.Message);
            //    }
            //}

            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"insert into Customers(CustomersName,Address,City,Email,PhoneNumber) 
                                    values(@CustomersName,@Address,@City,@Email,@PhoneNumber);select @@identity";
                    //@"INSERT INTO Customers (CustomerName,Address,City,Email,PhoneNumber)
                    //            VALUES (@CustomerName,@Address,@City,@Email,@PhoneNumber);select @@identity;";
                    var param = new
                    {
                        CustomersName = entity.CustomerName,
                        Address = entity.Address,
                        City = entity.City,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber
                    };
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CustomerId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {

                    throw new ArgumentException(sqlEx.Message);
                }
            }

            //try
            //{
            //    string query = @"INSERT INTO Customers(CustomersName,Address,City,Email, PhoneNumber) 
            //                    VALUES(@CustomersName,@Address,@City,@Email,@PhoneNumber );SELECT @@identity";
            //    _command = new SqlCommand(query, _connection);
            //    _command.Parameters.AddWithValue("@CustomersName", entity.CustomersName);
            //    _command.Parameters.AddWithValue("@Address", entity.Address);
            //    _command.Parameters.AddWithValue("@City", entity.City);
            //    _command.Parameters.AddWithValue("@Email", entity.Email);
            //    _command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            //    _connection.Open();
            //    entity.CustomersId = Convert.ToInt32(_command.ExecuteScalar());
            //    return entity;
            //}
            //catch (SqlException sqlEx)
            //{
            //    throw new ArgumentException(sqlEx.Message);
            //}
            //finally
            //{
            //    _connection.Close();
            //    _command.Dispose();
            //}
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"delete from Customers 
                                where CustomersId = @CustomersId";
                var param = new { CustomersId = id };
                conn.Execute(query, param);
            }
        }



        public IEnumerable<Customer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers order by CustomersName asc";
                var categories = conn.Query<Customer>(query);
                return categories;
            }
        }

        public IEnumerable<Customer> GetByCategoryName(string customersName)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers 
                                 WHERE CustomersName like @CustomersName";
                var param = new { CustomersName = "%" + customersName + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }

        public Customer GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"select * from Customers
                                 where CustomersId = @CustomersId";
                var param = new { CustomersId = id };
                var customers = conn.QueryFirstOrDefault<Customer>(query, param);
                //QueryFirstSingel itu satu kategory data aja yang diambil
                if (customers == null)
                {
                    throw new ArgumentException("data tidak ditemukan");
                }
                return customers;
            }
        }

        public IEnumerable<Customer> GetByProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCategory(int categoryName)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer entity)
        {
            using (SqlConnection con = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"UPDATE Customers 
                         SET CustomersName = @CustomersName, 
                             Address = @Address, 
                             City = @City, 
                             Email = @Email, 
                             PhoneNumber = @PhoneNumber
                         WHERE CustomersId = @CustomersId";
                    var param = new
                    {
                        CustomersName = entity.CustomerName,
                        Address = entity.Address,
                        City = entity.City,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber,
                        CustomersId = entity.CustomerId
                    };
                    con.Execute(query, param);
                    return entity;
                }
                catch (SqlException sqlEx)
                {

                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Customer> GetCustomers(int categoryName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string keyword) //oakai keyword itu kalau buat satu input tapi dipakai di dua tempat
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"select * from Customers
                            where CustomersName like @Keyword or City like @Keyword
                            order by CustomersName asc";
                var param = new { Keyword = "%" + keyword + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }

        IEnumerable<Customer> ICustomer.GetCustomersByNameOrCity(string customerName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Customer> ICrud<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

        Customer ICrud<Customer>.GetById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
