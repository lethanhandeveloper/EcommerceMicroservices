using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class OrderRepository
    {
        private readonly EcommerceDBContext _dbContext;

        public OrderRepository(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IdAndNameDto> AddNewOrder(OrderInputDto orderInputDto)
        {
            IdAndNameDto idAndNameDto = new IdAndNameDto();
            var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                Order order = new Order();
                order.UserName = orderInputDto.Username;

                await _dbContext.Orders.AddAsync(order);
                

                foreach (var product in orderInputDto.Products)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.Id;
                    orderDetail.ProductId = product.Id;
                    orderDetail.Quantity = product.Quantity ?? 0;

                    await _dbContext.OrderDetails.AddAsync(orderDetail);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                idAndNameDto.Id = order.Id;

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
            }

            return idAndNameDto;
        }


    //public Task<List<Order>> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<List<CategoryDto>> GetAllCategories()
    //{
    //    return await _dbContext.Categories.Include(c => c.products).Select(c => new CategoryDto()
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
