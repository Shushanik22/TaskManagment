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
        private readonly IWorkerService _iworkerservice;

        public ProjectController(IProjectService iprojectservice, IWorkerService iworkerService)
        {
            _iprojectservice = iprojectservice;
            _iworkerservice = iworkerService;
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
            if (projectadd.WorkerIds == null || projectadd.WorkerIds.Count == 0)
            {
                ModelState.AddModelError(nameof(ProjectAddEditViewModel.WorkerIds), "Please select product workers");
            }
            if (!ModelState.IsValid)
            {
                GetProductDropdownData();
                return View(projectadd);
            }
            _iprojectservice.Add(projectadd);
            return RedirectToAction();
        }

        private void GetProductDropdownData()
        {
            ViewBag.Workers = _iworkerservice.GetAll();

        }




    }
}

        

    

