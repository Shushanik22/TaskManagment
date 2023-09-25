using Microsoft.AspNetCore.Mvc;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;

namespace TaskManagment.Controllers
{
    public class TaskController : Controller
    {
        private readonly IProjectService _iprojectservice;

        public TaskController(IProjectService iprojectservice)
        {
            _iprojectservice = iprojectservice;
        }
        

        public IActionResult Add()
        {

        }



    }
}
