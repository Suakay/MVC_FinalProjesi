using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MVCFinalProje.Infrastrucre.Repositories.BookRepository;
using MVCFinalProje.Infrastrucre.Repositories.PublısherRepository;
using MVCFinalProje.Infrastructure.Repositories.AthourRepository;
using MVCFinalProje.Infrastructure.Seeds;
using MVCFinalProje.Infrastucre.AppContext;
using MVCFinalProje.Infrastucre.Repositories.AthourRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastucre.Extentios
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastucreServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContex>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));

            });
            services.AddScoped<IAuthorRepository, AuthorReository>();
            services.AddScoped<IPublısherRepository,PublısherRepository>();
            services.AddScoped<IBookRepository, BookRepository>();


            //Seed Data (Genelde Mig işlemlerinde yoruma almak zorunda kalabiliriz.)
           // AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();//ARAŞTIR.
            return services;
        }
    }
}

