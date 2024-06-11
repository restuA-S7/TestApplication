using RapidBootcamp.BackEndAPI.Models;
using RapidBootcamp.BackEndAPI.ViewModels;
using System.Data.SqlClient;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class OrderHeadersDAL : IOrderHeader
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        public OrderHeadersDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }
        public OrderHeader Add(OrderHeader entity)
        {
             //ambil lastOrderHeaderId
                //string lastOrderHeaderId = GetOrderLastHeaderId();
                //lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                //int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                //string newOrderHeaderInString = "INV-" + newOrderHeaderId.ToString().PadLeft(4, '0');

                //var newOrderHeader = new OrderHeader
                //{
                //    OrderHeaderId = newOrderHeaderInString
                //};

                //buat hal di atas masukan ke kontroler

                //return newOrderHeader;

               
                try
                {
                    string query = @"insert into OrderHeaders (OrderHeaderId, WalletId) 
                                 values (@OrderHeaderId, @WalletId)";
                    _command = new SqlCommand(query, _connection);
                    _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                    _command.Parameters.AddWithValue("@WalletId", entity.WalletId);
                    _connection.Open();
                    _command.ExecuteNonQuery(); //ini karena gak ada return value kalau pakai execute scalar itu ada return valuenya kalau peritnah insert aja tanpa return baru pakai itu
                                                //kalau kembalianya satu tabel ya pakai data reader

                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
            }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            try
            {
                List<OrderHeader> orderHeaders = new List<OrderHeader>();
                string query = @"SELECT * FROM ViewOrderHeaderInfo
                                order by OrderHeaderId desc";
                _command = new SqlCommand(query, _connection);
                _connection.Open();

                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        orderHeaders.Add(new OrderHeader
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            TransactionDate = Convert.ToDateTime(_reader["TransactionDate"]),
                            Wallet = new Wallet
                            {
                                CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                                Customer = new Customer
                                {
                                    CustomerName = _reader["CustomerName"].ToString()
                                },
                                WalletType = new WalletType
                                {
                                    WalletName = _reader["WalletName"].ToString()
                                }
                            }
                        });
                    }
                }
                _reader.Close();
                return orderHeaders;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeader(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeaderName(string productName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeaderWithCategory()
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            try
            {
                List<ViewOrderHeaderInfo> viewOrderHeaderInfos = new List<ViewOrderHeaderInfo>();
                string query = @"SELECT * FROM ViewOrderHeaderInfo
                                order by OrderHeaderId desc";
                _command = new SqlCommand(query, _connection);
                _connection.Open();

                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        viewOrderHeaderInfos.Add(new ViewOrderHeaderInfo
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString()
                        });
                    }
                }
                _reader.Close();
                return viewOrderHeaderInfos;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public string GetOrderLastHeaderId()
        {
            string query = @"select top 1 OrderHeaderId from OrderHeaders 
                             order by OrderHeaderId desc";
            try
            {
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                var lastOrderHeaderId = _command.ExecuteScalar().ToString(); //kenapa execute scalar karen cuman satu
                if (lastOrderHeaderId == null)
                {
                    throw new ArgumentException("OrderHeaderId not found");
                }
                return lastOrderHeaderId;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }
    }
}
