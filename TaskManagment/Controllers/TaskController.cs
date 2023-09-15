using Microsoft.AspNetCore.Mvc;

namespace TaskManagment.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
