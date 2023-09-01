using System.ComponentModel;

namespace FoodShop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        public virtual Category Category { get; set; }

    }
}
