namespace FoodShop.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
