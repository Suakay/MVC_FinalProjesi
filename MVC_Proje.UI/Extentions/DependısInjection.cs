using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using MVCFinalProje.Infrastucre.AppContext;

namespace MVC_Proje.UI.Extentions
{
    public  static class DependısInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.DurationInSeconds = 3;
                config.Position = NotyfPosition.BottomRight;
                config.IsDismissable = true;
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContex>();
            return services;    

        }
    }
}
