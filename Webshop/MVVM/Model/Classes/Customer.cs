namespace Webshop.MVVM.Model.Classes
{
    internal class Customer
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PointBalance { get; set; }

        public Customer(int id, int name, int phone, string email, string address, int pointBalance)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            PointBalance = pointBalance;
        }
    }
}
