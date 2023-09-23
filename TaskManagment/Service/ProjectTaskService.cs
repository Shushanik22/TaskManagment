using Humanizer;
using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;
using TaskManagment.ViewModel;

namespace TaskManagment.Service
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _iptaskrepository;

        public ProjectTaskService(IProjectTaskRepository ipyaskrepository)
        {
            _iptaskrepository = ipyaskrepository;
        }



        public void Add(TaskAddEditViewModel taskadd)
        {
            ProjectTask task = new ProjectTask
            {

                Description = taskadd.Description,
                Title = taskadd.Title,




            };
        }

        public TaskAddEditViewModel GetById(int id)
        {
            var ProjectTask  = _iptaskrepository.GetById(id);
            return new TaskAddEditViewModel
            {
                Description = ProjectTask.Description,
                Title = ProjectTask.Title,

            };

            
        }
        public List<TaskAddEditViewModel> GetAll(TaskAddEditViewModel model)
        {
           var taskproject = _iptaskrepository.GetAll(model);
            var taskprojectSelect = taskproject.Select(x => new TaskAddEditViewModel
            {
                Title = x.Title,
                Description = x.Description,
                 

            }).ToList();
            return taskprojectSelect;

        }

       

      

        public void Update(TaskAddEditViewModel taskadd)
        {
            var update = _iptaskrepository.GetById(taskadd.Id);
            update.Title = taskadd.Title;
            update.Description = taskadd.Description;
        }
    }
}
