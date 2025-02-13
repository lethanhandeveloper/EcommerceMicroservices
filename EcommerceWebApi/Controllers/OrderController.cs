using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using EcommerceWebApi.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    public class OrderController : ApiController
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly UnitOfWork _unitOfWork;

        public OrderController(ICategoryRepository categoryRepository, UnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        //[HttpPost("getAll")]
        //public async Task<List<CategoryDto>> GetAll()
        //{
        //   List<Category> categories =  await _unitOfWork._categoryRepository.GetAll();
        //   return categories.Adapt(new List<CategoryDto>());
        //}

        [HttpPost("add")]
        public async Task<IdAndNameDto> Add(OrderInputDto order)
        {
            return await _unitOfWork._orderRepository.AddNewOrder(order);
        }
    }
}
