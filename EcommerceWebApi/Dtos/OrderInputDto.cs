using EcommerceWebApi.Entities;

namespace EcommerceWebApi.Dto
{
    public class OrderInputDto : CommonDto
    {
       public string Username { get; set; }
       public List<ProductDto> Products { get; set; }
    }
}
