using BooksStoreAPI.Application.Interfaces;
using BookStoreAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreAPI.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<BookStoreDbContext>(opt => opt
                .UseSqlServer("Server=localhost,1433; Database=BooksDB;User Id=sa; Password=password_01;"));
            return services;
        }
    }
}
