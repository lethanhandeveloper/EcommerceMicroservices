using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext DbContext { get; set; }

        public DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        //public async Task<List<CategoryDto>> GetAllCategories()
        //{
        //    return await _dbContext.categories.Include(c => c.products).Select(c => new CategoryDto()
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        Products = c.products.Select(p => new ProductDto() { 
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price
        //        }).ToList()
        //    }).ToListAsync();
        //}

        //public async Task<List<Product>> GetAllProducts()
        //{
        //    return await _dbContext.products.Include(c => c.Category).ToListAsync();
        //}
    }
}
