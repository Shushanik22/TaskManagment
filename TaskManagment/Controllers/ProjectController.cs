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
        public IActionResult Add()
        {
            GetProductDropdownData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProjectAddEditViewModel model)
        {
            if (model.WorkerIds == null || model.WorkerIds.Count == 0)
            {
                ModelState.AddModelError(nameof(ProjectAddEditViewModel.WorkerIds), "Please select product categories");
            }
            if (!ModelState.IsValid)
            {
                GetProductDropdownData();
                return View(model);
            }
            _iprojectservice.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _iprojectservice.GetById(id);
           
            GetProductDropdownData();
            return View(model);
         
          
        }
        
        [HttpPost]
        public IActionResult Edit(ProjectAddEditViewModel model)
        {
            _iprojectservice.Update(model);
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(ProjectAddEditViewModel model)
        {
            _iprojectservice.Delete(model);
             return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult AddEdit(ProjectAddEditViewModel projectadd /*IFormFile formFile*/)
        //{
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
        //    //}
        //    
        private void GetProductDropdownData()
        {
            ViewBag.Workers = _iworkerservice.GetAll();

        }




    }
}

        

    

