using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EcommerceWebApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDBContext _dbContext;

        public ProductRepository(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddNewProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.Include(c => c.Category).ToListAsync();
        }

        public async Task<Guid> Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            Product product =  await _dbContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetPaginatedProduct(SortFilterPagingProductDto sortFilterPagingProductDto)
        {
            Expression<Func<Product, bool>> filter1 = p => p.Name.Contains(sortFilterPagingProductDto.Name);
           

            List<Product> products = await _dbContext.Products.Where(filter1).Skip((sortFilterPagingProductDto.PageIndex - 1) * sortFilterPagingProductDto.PageSize).Take(sortFilterPagingProductDto.PageSize).ToListAsync();
            return products;
        }
    }
}
