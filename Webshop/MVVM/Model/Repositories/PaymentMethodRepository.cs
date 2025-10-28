using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class PaymentMethodRepository : IRepository<PaymentMethod>
    {
        private readonly string _connectionString;
        public PaymentMethodRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }
    }
}
