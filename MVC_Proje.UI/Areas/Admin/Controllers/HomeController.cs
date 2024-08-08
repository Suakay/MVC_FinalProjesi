using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Proje.UI.Areas.Admin.Controllers
{
   
    public class HomeController :AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
