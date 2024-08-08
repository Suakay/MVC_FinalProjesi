using Microsoft.Extensions.DependencyInjection;
using MVCFinalProjeBusiness.Services.AuthorServices;
using MVCFinalProjeBusiness.Services.PubllısherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Extentions
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublısherService, PublisherService>();

            return services;
        } 
    }
}
