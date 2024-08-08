using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Proje.UI.Controllers;

namespace MVC_Proje.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Employee")]
    public class AdminBaseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
