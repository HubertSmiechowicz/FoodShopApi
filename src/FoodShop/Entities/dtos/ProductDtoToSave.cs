namespace FoodShop.Entities.dtos
{
    public class ProductDtoToSave
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
