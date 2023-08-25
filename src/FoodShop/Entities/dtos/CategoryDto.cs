namespace FoodShop.Entities.dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDtoToRead> Products { get; set; }
    }
}
