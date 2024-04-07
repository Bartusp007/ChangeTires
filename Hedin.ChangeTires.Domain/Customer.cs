namespace Hedin.ChangeTires.Domain
{
    public class Customer
    {
        public long Id { get; private set; }
        public string CustomerName { get; private set; }
        public string Email { get; private set; }

        public Customer(string customerName, string email)
        {
            CustomerName = customerName;
            Email = email;
        }

        public static Customer Create(string customerName, string email)
            => new Customer(customerName, email);

    }
}