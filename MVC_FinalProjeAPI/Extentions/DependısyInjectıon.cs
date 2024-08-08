using Microsoft.EntityFrameworkCore;
using MVCFinalProje.Infrastucre.AppContext;

namespace MVC_FinalProjeAPI.Extentions
{
    public static  class DependısyInjectıon
    {
        public static IServiceCollection AddApiService(this IServiceCollection services)
        {
            public static IServiceCollection AddInfrastucreServices(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<AppDbContex>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));

                });            }
    }
}
