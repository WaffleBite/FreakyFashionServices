namespace FreakyFashionServices.Order.Models.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer()
        {

        }
        public Customer(string customerId, string firstName, string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}