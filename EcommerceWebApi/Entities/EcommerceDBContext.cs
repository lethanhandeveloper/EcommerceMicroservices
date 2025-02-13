using EcommerceWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Entity
{
    public class EcommerceDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        public EcommerceDBContext(DbContextOptions options) : base(options)
        {
        }

        public EcommerceDBContext()
        {
        }
    }
}
