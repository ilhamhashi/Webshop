namespace Webshop.MVVM.Model.Classes
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Points { get; set; }

        public Customer(int customerId, string firstName, string lastName, string email, string address, string city, string country, int points)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            Country = country;
            Points = points;
        }

        public Customer(string firstName, string lastName, string email, string address, string city, string country, int points)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            Country = country;
            Points = points;
        }
    }
}
