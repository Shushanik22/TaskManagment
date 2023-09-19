using Microsoft.AspNetCore.Mvc;

namespace TaskManagment.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
