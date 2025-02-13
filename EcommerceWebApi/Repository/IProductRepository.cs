using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entity;

namespace EcommerceWebApi.Repository
{
    public interface IProductRepository
    {
        Task<Guid> AddNewProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<List<Product>> GetPaginatedProduct(SortFilterPagingProductDto sortFilterPagingDto);
        Task<Guid> Delete(Product product);
    }
}
