using Microsoft.AspNetCore.Mvc;
using Mission08_Team0308.Models;
using System.Diagnostics;

namespace Mission08_Team0308.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
