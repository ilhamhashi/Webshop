using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Webshop.MVVM.Model.Classes;
using Webshop.MVVM.Model.Repositories;
using Webshop.Services;

namespace Webshop.MVVM.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly SqlConnection _connection;
        private readonly OrderService _orderService;
        
        public ObservableCollection<OrderItem> OrderItems { get; set; }

        private Order newOrder;
        public Order NewOrder
        {
            get { return newOrder; }
            set { newOrder = value; }
        }

        public ICommand CreateOrderCommand { get; }

        public MainWindowViewModel()
        {
            _connection = new SqlConnection(Config.GetConnectionString("DefaultConnection"));
            _orderRepository = new OrderRepository(_connection);
            _orderItemRepository = new OrderItemRepository(_connection);
            _productRepository = new ProductRepository(_connection);
            _orderService = new OrderService(_connection, _orderRepository, _orderItemRepository, _productRepository);

            NewOrder = new Order(DateTime.Now, 10, 1, 1, 1);
            OrderItems = new ObservableCollection<OrderItem>();

            OrderItem orderitem1 = new OrderItem(1, 2, 4999.99, true);
            OrderItem orderitem2 = new OrderItem(2, 1, 3999.99, true);

            OrderItems.Add(orderitem1);
            OrderItems.Add(orderitem2);

            CreateOrderCommand = new RelayCommand(_ => _orderService.CreateOrder(NewOrder, OrderItems.ToList()), _ => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
