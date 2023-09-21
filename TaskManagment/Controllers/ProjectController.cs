using Microsoft.AspNetCore.Mvc;
using TaskManagment.Service;
using TaskManagment.Interface;
using Microsoft.Build.Evaluation;
using TaskManagment.ViewModel;

namespace TaskManagment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _iprojectservice;
        
        public ProjectController(IProjectService iprojectservice)
        {
            _iprojectservice = iprojectservice;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(ProjectAddEditViewModel projectadd)
        {
           _iprojectservice.Add(projectadd);
            return View();

        }

        

    }
}
