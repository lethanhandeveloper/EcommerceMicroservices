namespace EcommerceWebApi.Dtos
{
    public class SortFilterPagingDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
