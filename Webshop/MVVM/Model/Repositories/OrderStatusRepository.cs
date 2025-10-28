using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {
        private readonly string _connectionString;
        public OrderStatusRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(OrderStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
