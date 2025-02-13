namespace EcommerceWebApi.Dto
{
    public class ProductDto : CommonDto
    {
       public string Name { get; set; }
       public int Price { get; set; }
       public string? CategoryName { get; set; }
       public int? Quantity { get; set; }
    }
}
