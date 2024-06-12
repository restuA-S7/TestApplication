using RapidBootcamp.BackEndAPI.Models;
using System.Data.SqlClient;
using System.Transactions;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class OrderDetailsDAL : IOrderDetail
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private readonly IProduct _product;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderDetailsDAL(IConfiguration config, IProduct product)
        {
            _config = config;
            _product = product;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }
        public OrderDetail Add(OrderDetail entity)
        {
            //transaction scope disini gak jadi udah di order header dal
            //using(TransactionScope scope = new TransactionScope()) //tansaction scope itu untuk memastikan dua/lebih eksekusi itu bener2 dijalankan dulu kalau engga di kembalikan
            //{
                //cara panggil ini di api order header ya sekalian dan pakainya ini
                /*{
                    "orderHeaderId": "",
                    "walletId": 5,
                    "orderDetails": [
                        {
                        "orderHeaderId": "",
                        "productId": 11,
                        "qty": 2,
                        "price": 2000
                        }
                    ]
                }*/
                try
                {
                    //ambil stock masih ada engga
                    int stock = _product.CheckProductStock(entity.ProductId);
                    if (stock < entity.Qty)
                    {
                        throw new ArgumentException("Stock is not enaugh");
                    }

                    string query = @"insert into OrderDetails(OrderHeaderId,ProductId,Qty,Price) 
                                 values(@OrderHeaderId,@ProductId,@Qty,@Price);
                                 select @@identity";
                    _command = new SqlCommand(query, _connection);
                    _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                    _command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    _command.Parameters.AddWithValue("@Qty", entity.Qty);
                    _command.Parameters.AddWithValue("@Price", entity.Price);
                    _connection.Open();

                    int id = Convert.ToInt32(_command.ExecuteScalar());//pakai ini karena kita pakai @identity soalnya karen auto increment ininnya
                    entity.OrderDetailId = id;

                    //updaet stock di prouduc
                    string queryUpdate = @"update Products set Stock=Stock-@Qty Where ProductId=@ProductId";
                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, _connection);
                    cmdUpdate.Parameters.AddWithValue("@Qty", entity.Qty);
                    cmdUpdate.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    cmdUpdate.ExecuteNonQuery();

                    //scope.Complete();

                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
                //catch (TransactionAbortedException tranEx)
                //{
                //    throw new ArgumentException(tranEx.Message);
                //}
                finally
                {
                    //_command.Dispose(); ini dimatikan karena kalau engga stock is not enaughnya gak aktif
                    _connection.Close();
                    //scope.Dispose();
                }
            //} 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId)
        {
            try
            {
                string query = @"SELECT * FROM ViewOrderDetail
                                WHERE OrderHeaderId=@OrderHeaderId
                                order by ProductName asc";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("OrderHeaderId", orderHeaderId);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                if( _reader.HasRows )
                {
                    while( _reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailId = Convert.ToInt32(_reader["OrderDetailId"]);
                        orderDetail.OrderHeaderId = _reader["OrderHeaderId"].ToString();
                        orderDetail.ProductId = Convert.ToInt32(_reader["ProductId"]);
                        orderDetail.Product = new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString()
                        };
                        orderDetail.Qty = Convert.ToInt32(_reader["Qty"]);
                        orderDetail.Price = Convert.ToDecimal(_reader["Price"]);
                        orderDetails.Add(orderDetail);
                    }
                }
                _reader.Close();
                return orderDetails;

            }
            catch (SqlException sqlEx)
            {

                throw new AggregateException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public OrderDetail Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAmount(string orderHeaderId)
        {
            try
            {
                string query = @"select sum(Price * Qty) from OrderDetails
                                where OrderHeaderId = @OrderHeaderId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("OrderHeaderId", orderHeaderId);
                _connection.Open();
                decimal totalAmount = Convert.ToDecimal(_command.ExecuteScalar());
                return totalAmount;
            }
            catch (SqlException sqlEx)
            {

                throw new ArgumentException(sqlEx.Message); 
            }
            //bapak ini dimatikan
            //finally
            //{
            //    _command.Dispose();
            //    _connection.Close();
            //}
        }
    }
}
