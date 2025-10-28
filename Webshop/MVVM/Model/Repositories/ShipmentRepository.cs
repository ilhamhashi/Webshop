using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class ShipmentRepository : IRepository<Shipment>
    {
        private readonly string _connectionString;
        public ShipmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Shipment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shipment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Shipment entity)
        {
            throw new NotImplementedException();
        }
    }
}
