using EcommerceWebApi.Entities;

namespace EcommerceWebApi.Dto
{
    public class CategoryDto : CommonDto
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public List<ProductDto> Products { get; set; }
    }
}
