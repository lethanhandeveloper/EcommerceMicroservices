
using EcommerceWebApi.Dto;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using EcommerceWebApi.Repository;
using EcommerceWebApi.Services;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EcommerceDBContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDBContext")); 
            });

            TypeAdapterConfig<Product, ProductDto>
            .NewConfig()
            .Map(dest => dest.CategoryName, src => src.Category != null ? src.Category.Name : null);

            //TypeAdapterConfig<List<Product>, List<ProductDto>>
            //.NewConfig()
            //.Map(dest => dest.Select(d => d.Name), src => src.Select(p => p.Category) != null ? src.Select(p => p.Category).FirstOrDefault().Name : null);

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
            builder.Services.AddScoped<OrderRepository>();

            builder.Services.AddSingleton<SingletonService>();
            builder.Services.AddScoped<ScopeService>();
            builder.Services.AddTransient<TransientService>();

            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddMediatR(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}