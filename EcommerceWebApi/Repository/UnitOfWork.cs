using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class UnitOfWork
    {
        public readonly EcommerceDBContext _dbContext;
        public readonly OrderRepository _orderRepository;
        public readonly IRepository<Category> _categoryRepository;

        public UnitOfWork(EcommerceDBContext dbContext, OrderRepository orderRepository, IRepository<Category> categoryRepository)
        {
            _dbContext = dbContext;

            _categoryRepository = categoryRepository;
            _categoryRepository.DbContext = _dbContext;

            _orderRepository = orderRepository;
            //_orderRepository.DbContext = _dbContext;    
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
