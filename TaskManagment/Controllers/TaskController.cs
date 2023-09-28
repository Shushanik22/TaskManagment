using Microsoft.AspNetCore.Mvc;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;
using TaskManagment.ViewModel;
using TaskManagment.Data.Repositories;
using TaskManagment.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManagment.Data.Entities;


namespace TaskManagment.Controllers
{
    public class TaskController : Controller
    {
        private readonly IProjectTaskService _iprojectTaskservice;
     


        public TaskController(IProjectTaskService iprojectTaskservice)
        {
            _iprojectTaskservice = iprojectTaskservice;
            
        }
        public IActionResult Index()
        {
            var getall = _iprojectTaskservice.GetAll();
            return View(getall);
            
        }

        public IActionResult Add(TaskAddEditViewModel model)
        {

       
            _iprojectTaskservice.GetById(model.Id);
            if (model.Id > 0)
            {
                
                var getallquerry = _iprojectTaskservice.GetAll();
            }
            else
            {
               _iprojectTaskservice.Add(model);

            }
            return View();
            


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var querryedit = _iprojectTaskservice.GetById(id);
            return View(querryedit);
        }
        [HttpPost]
        public IActionResult Edit(TaskAddEditViewModel model)
        {
            _iprojectTaskservice.Update(model);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(TaskAddEditViewModel model)
        {
            
            _iprojectTaskservice.Delete(model);
            return View("Index");

        }


    }
}
