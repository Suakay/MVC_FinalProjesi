using Microsoft.AspNetCore.Mvc;
using MVC_Proje.UI.Areas.Admin.Controllers;

namespace MVC_Proje.UI.Controllers
{
    public class AuthorController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
