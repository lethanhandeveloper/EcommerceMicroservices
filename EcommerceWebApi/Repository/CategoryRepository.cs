using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDBContext _dbContext;

        public CategoryRepository(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _dbContext.Categories.Include(c => c.products).Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.products.Select(p => new ProductDto() { 
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            }).ToListAsync();
        }

        //public async Task<List<Product>> GetAllProducts()
        //{
        //    return await _dbContext.products.Include(c => c.Category).ToListAsync();
        //}
    }
}
