using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;

namespace EcommerceWebApi.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
    }
}
