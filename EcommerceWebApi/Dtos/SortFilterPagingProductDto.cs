namespace EcommerceWebApi.Dtos
{
    public class SortFilterPagingProductDto : SortFilterPagingDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
