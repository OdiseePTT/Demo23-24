using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Todo.Models;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("TodoItems");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}