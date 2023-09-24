using Microsoft.AspNetCore.Mvc;
using TaskManagment.Service;
using TaskManagment.Interface;
using Microsoft.Build.Evaluation;
using TaskManagment.ViewModel;
using Microsoft.CodeAnalysis;

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

        public IActionResult Index()
        {
            var list=_iprojectservice.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddEdit(int id)
        {
         
            var model = _iprojectservice.GetById(id);
            if (model==null)
            {
                GetProductDropdownData();
                return View();
            }
            GetProductDropdownData();
            _iprojectservice.AddEdit(model); ;
            return View(model);

        }

        [HttpPost]
        public IActionResult AddEdit(ProjectAddEditViewModel projectadd /*IFormFile formFile*/)
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
            _iprojectservice.AddEdit(projectadd);
            return RedirectToAction("addedit");
        }

        private void GetProductDropdownData()
        {
            ViewBag.Workers = _iworkerservice.GetAll();

        }




    }
}

        

    

