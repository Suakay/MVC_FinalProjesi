using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Proje.UI.Controllers
{
    public class BaseController : Controller
    {
        protected INotyfService notyfService => HttpContext.RequestServices.GetService(typeof(INotyfService)) as INotyfService;
        protected void SuccessNotyf(string message)
        {
            notyfService.Success(message);
        }
        protected void ErrorNotyf(string message)
        {
            notyfService.Error(message);


        }
    }
}
