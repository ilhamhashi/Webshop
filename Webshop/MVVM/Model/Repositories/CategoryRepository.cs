using Webshop.MVVM.Model.Classes;

namespace Webshop.MVVM.Model.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Category>.Add(Category entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> IRepository<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Category>.Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
