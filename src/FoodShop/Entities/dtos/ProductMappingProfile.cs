using AutoMapper;

namespace FoodShop.Entities.dtos
{
    public class ProductMappingProfile : Profile
    {
        public FoodShopDbContext _db = new FoodShopDbContext();

        public ProductMappingProfile()
        {
            // category mapping

            CreateMap<Category, SingleCategoryDto>();
            CreateMap<Category, CategoryDto>();

            // product mapping

            CreateMap<ProductDtoToSave, Product>(); 
            CreateMap<Product, ProductDtoToRead>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => _db.Categories.First(i => i.Id == s.CategoryId).Name));

            // customer mapping

            CreateMap<CustomerDtoToWrite, Customer>();

            // order mapping

            CreateMap<Order, OrderDtoToRead>();

            // order_product mapping

            CreateMap<OrderProduct, OrderProductDtoToRead>()
                .ForMember(m => m.ProductName, c => c.MapFrom(s => _db.Products.First(p => p.Id == s.ProductId).Name));
        }
    }
}
