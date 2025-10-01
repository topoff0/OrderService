
namespace OrderService.Core.Entities
{
    public class Customer
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        private Customer() { }

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = [];
    }
}