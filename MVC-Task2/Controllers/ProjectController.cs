using Microsoft.AspNetCore.Mvc;

namespace MVC_Task2.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
