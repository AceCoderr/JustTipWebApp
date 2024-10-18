using JustTip.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustTip.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
