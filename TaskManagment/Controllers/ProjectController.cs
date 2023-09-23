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
        //private readonly IWebHostEnvironment _hostEnvironment;

        public ProjectController(IProjectService iprojectservice, IWorkerService iworkerService/*IWebHostEnvironment hostEnvironment*/)
        {
            _iprojectservice = iprojectservice;
            _iworkerservice = iworkerService;
            //_hostEnvironment = hostEnvironment;

        }

        public IActionResult Index(ProjectListViewModel model)
        {
            var list=_iprojectservice.GetAll(model);
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            GetProductDropdownData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProjectAddEditViewModel projectadd /*IFormFile formFile*/)
        {
            //if (formFile == null)
            //{
            //    projectadd.Picture = null;
            //}
            //else
            //{
            //    string fileName = Guid.NewGuid() + System.IO.Path.GetExtension(formFile.FileName);
            //    string path = $"{_hostEnvironment.WebRootPath}/assets/img/project/{fileName}";
            //    projectadd.Picture = fileName;
            //    using var fileStream = new FileStream(path, FileMode.Create);
            //    formFile.CopyTo(fileStream);
            //}
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
            return RedirectToAction("add");
        }

        private void GetProductDropdownData()
        {
            ViewBag.Workers = _iworkerservice.GetAll();

        }




    }
}

        

    

