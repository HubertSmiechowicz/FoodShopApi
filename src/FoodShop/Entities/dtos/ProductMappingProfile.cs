using AutoMapper;

namespace FoodShop.Entities.dtos
{
    public class ProductMappingProfile : Profile
    {
        public FoodShopDbContext _db = new FoodShopDbContext();

        public ProductMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<ProductDtoToSave, Product>(); 
            CreateMap<Product, ProductDtoToRead>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => _db.Categories.First(i => i.Id == s.CategoryId).Name));
        }
    }
}
