using Library.API.Context;
using Library.API.Persistence;
using Library.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Startups
{
    public static class StartupServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryContext")));

            services.AddScoped<ILibraryContext, LibraryContext>();

            services.AddScoped<IBooksService, BooksService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
