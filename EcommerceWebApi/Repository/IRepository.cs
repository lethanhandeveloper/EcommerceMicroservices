using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }
        DbContext DbContext { get; set; }

        public Task<List<T>> GetAll();
    }
}
