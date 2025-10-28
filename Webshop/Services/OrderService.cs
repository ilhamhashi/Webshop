using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Webshop.MVVM.Model.Classes;
using Webshop.MVVM.Model.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        private readonly SqlConnection _connection;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(SqlConnection connection, IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository, IRepository<Product> productRepository)
        {
            _connection = connection;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }

        public void CreateOrder(Order order, List<OrderItem> orderItems)
        {
            using (var connection = _connection)
            {
                connection.Open();

                using (SqlTransaction transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        // Opret ordre
                        _orderRepository.Add(order);

                        // Opret ordrelinjer
                        foreach (var item in orderItems)
                        {
                            item.OrderId = order.OrderId; // Sæt OrderId for ordrelinjen
                            _orderItemRepository.Add(item);

                            // Opdater lagerbeholdning
                            var product = _productRepository.GetById(item.ProductId);
                            product.StockQuantity -= item.Quantity;
                            _productRepository.Update(product);
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Rul tilbage transaktionen ved fejl
                        transaction.Rollback();
                        throw; // Re-throw exception to handle it upstream
                    }
                }
            }
        }
    }
}
