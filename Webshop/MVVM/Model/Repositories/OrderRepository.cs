using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("uspGetAllOrders", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        (
                            (int)reader["OrderId"],
                            (DateTime)reader["OrderDate"],
                            (int)reader["PointsUsed"],
                            (int)reader["CustomerId"],
                            (int)reader["OrderStatusId"],
                            (int)reader["PaymentMethodId"]
                        ));
                    }
                }
            }
            return orders;
        }

        public Order GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("uspGetOrderById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        (
                            (int)reader["OrderId"],
                            (DateTime)reader["OrderDate"],                           
                            (int)reader["PointsUsed"],
                            (int)reader["CustomerId"],
                            (int)reader["OrderStatusId"],
                            (int)reader["PaymentMethodId"]
                        );
                    }
                }
            }
            return null;
        }

        public void Add(Order entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("uspCreateOrder", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderDate", SqlDbType.DateTime2).Value = entity.OrderDate;
                command.Parameters.AddWithValue("@PointsUsed", SqlDbType.Int).Value = entity.PointsUsed;
                command.Parameters.AddWithValue("@CustomerId", SqlDbType.Int).Value = entity.CustomerId;
                command.Parameters.AddWithValue("@OrderStatusId", SqlDbType.Int).Value = entity.OrderStatusId;
                command.Parameters.AddWithValue("@PaymentMethodId", SqlDbType.Int).Value = entity.PaymentMethodId;

                SqlParameter orderIdParam = new SqlParameter("@OrderId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(orderIdParam);

                connection.Open();
                command.ExecuteNonQuery();
                entity.OrderId = (int)orderIdParam.Value;
            }
        }

        public void Update(Order entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("uspUpdateOrder", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderId", SqlDbType.Int).Value = entity.OrderId;
                command.Parameters.AddWithValue("@OrderDate", SqlDbType.DateTime2).Value = entity.OrderDate;
                command.Parameters.AddWithValue("@PointsUsed", SqlDbType.Int).Value = entity.PointsUsed;
                command.Parameters.AddWithValue("@CustomerId", SqlDbType.Int).Value = entity.CustomerId;
                command.Parameters.AddWithValue("@OrderStatusId", SqlDbType.Int).Value = entity.OrderStatusId;
                command.Parameters.AddWithValue("@PaymentMethodId", SqlDbType.Int).Value = entity.PaymentMethodId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("uspDeleteOrder", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderId", SqlDbType.Int).Value = id;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
