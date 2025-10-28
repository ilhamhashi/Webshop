using Microsoft.Extensions.Configuration;
using Webshop.MVVM.Model.Classes;
using Webshop.MVVM.Model.Repositories;

namespace Webshop.MVVM.ViewModel
{
    public class MainWindowViewModel
    {

        public static IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public IRepository<Customer> customerRepository = new CustomerRepository(Config.GetConnectionString("DefaultConnection"));


        public MainWindowViewModel()
        {

            /*
            // Adding a new customer
            customerRepository.Add(new Customer("NyKundeNavn", "NyKundeTel", "NyKunde@gmail.com"));

            //Getting all customers
            var customers = customerRepository.GetAll();
            foreach (var customer in customers)
            {
                MessageBox.Show($"{customer.Name}", "Navn", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Updating a customer
            var updatecustomer = customerRepository.GetById(4);
            if (updatecustomer != null)
            {
                updatecustomer.PointBalance = 800;
                customerRepository.Update(updatecustomer);
            }

            //Deleting a customer
            customerRepository.Delete(1);

            */
        }
    }
}
