
using Microsoft.AspNetCore.RateLimiting;

namespace ApiGateway
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
            builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("Yarp")); ;
            builder.Services.AddSwaggerGen();
            builder.Services.AddRateLimiter(rateLimiterOptions =>
            {
                rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
                {
                    options.Window = TimeSpan.FromSeconds(10);
                    options.PermitLimit = 1;
                });
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("secure", policy =>
                policy.RequireAuthenticatedUser());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRateLimiter();

            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapReverseProxy(proxyApp =>
            {
                proxyApp.UseRateLimiter(); 
            });

            app.Run();
        }
    }
}