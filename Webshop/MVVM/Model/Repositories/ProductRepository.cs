using Microsoft.Data.SqlClient;
using System.Data;
using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SqlConnection _connection;
        public ProductRepository(SqlConnection connectionString)
        {
            _connection = connectionString;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using (var command = new SqlCommand("uspGetAllProducts", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        (
                            (int)reader["ProductId"],
                            (string)reader["ProductName"],
                            (int)reader["CategoryId"],
                            (double)reader["Price"],
                            (int)reader["StockQuantity"]
                        ));
                    }
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            using (var command = new SqlCommand("uspGetProductById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        (
                            (int)reader["ProductId"],
                            (string)reader["ProductName"],
                            (int)reader["CategoryId"],
                            (double)reader["Price"],
                            (int)reader["StockQuantity"]
                        );
                    }
                }
            }
            return null;
        }

        public void Add(Product entity)
        {
            using (var command = new SqlCommand("uspCreateProduct", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
                command.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = entity.CategoryId;
                command.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = entity.Price;
                command.Parameters.AddWithValue("@StockQuantity", SqlDbType.Int).Value = entity.StockQuantity;

                SqlParameter productIdParam = new SqlParameter("@ProductId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(productIdParam);

                command.ExecuteNonQuery();
                entity.ProductId = (int)productIdParam.Value;
            }
        }

        public void Delete(int id)
        {
            using (var command = new SqlCommand("uspDeleteProduct", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }

        public void Update(Product entity)
        {
            using (var command = new SqlCommand("uspUpdateProduct", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = entity.ProductId;
                command.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
                command.Parameters.AddWithValue("@CategoryId", SqlDbType.Int).Value = entity.CategoryId;
                command.Parameters.AddWithValue("@Price", SqlDbType.Decimal).Value = entity.Price;
                command.Parameters.AddWithValue("@StockQuantity", SqlDbType.Int).Value = entity.StockQuantity;

                command.ExecuteNonQuery();
            }
        }
    }
}
