using Microsoft.Data.SqlClient;
using System.Data;
using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly SqlConnection _connection;
        public OrderItemRepository(SqlConnection connectionString)
        {
            _connection = connectionString;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            var orderitems = new List<OrderItem>();
            using (var command = new SqlCommand("uspGetAllOrderItems", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderitems.Add(new OrderItem
                        (
                            (int)reader["OrderId"],
                            (int)reader["PointsUsed"],
                            (int)reader["Quantity"],
                            (double)reader["Price"],
                            (bool)reader["SelectedToCart"]
                        ));
                    }
                }
            }
            return orderitems;
        }

        public OrderItem GetById(int id)
        {
            using (var command = new SqlCommand("uspGetOrderItemById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new OrderItem
                        (
                            (int)reader["OrderId"],
                            (int)reader["PointsUsed"],
                            (int)reader["Quantity"],
                            (double)reader["Price"],
                            (bool)reader["SelectedToCart"]
                        );
                    }
                }
            }
            return null;
        }

        public void Add(OrderItem entity)
        {
            using (var command = new SqlCommand("uspCreateOrderItem", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderId", SqlDbType.Int).Value = entity.OrderId;
                command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = entity.ProductId;
                command.Parameters.AddWithValue("@Quantity", SqlDbType.Int).Value = entity.Quantity;
                command.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = entity.Price;
                command.Parameters.AddWithValue("@SelectedToCart", SqlDbType.Bit).Value = entity.SelectedToCart;

                command.ExecuteNonQuery();
            }
        }

        public void Update(OrderItem entity)
        {
            using (var command = new SqlCommand("uspUpdateOrderItem", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderId", SqlDbType.Int).Value = entity.OrderId;
                command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = entity.ProductId;
                command.Parameters.AddWithValue("@Quantity", SqlDbType.Int).Value = entity.Quantity;
                command.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = entity.Price;
                command.Parameters.AddWithValue("@SelectedToCart", SqlDbType.Bit).Value = entity.SelectedToCart;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var command = new SqlCommand("uspDeleteOrderItem", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }
    }
}
