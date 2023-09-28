using Humanizer;
using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;
using TaskManagment.ViewModel;
using TaskManagment.Data;

namespace TaskManagment.Service
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _iptaskrepository;
        private readonly IUnitOfWork _uow;


        public ProjectTaskService(IProjectTaskRepository ipyaskrepository, IUnitOfWork uow)
        {
            _iptaskrepository = ipyaskrepository;
            _uow = uow;
        }



        public void Add(TaskAddEditViewModel taskadd)
        {
            ProjectTask task = new ProjectTask
            {

                Description = taskadd.Description,
                Title = taskadd.Title,

            };
            _uow.SaveChanges();
        }

        public void Delete(TaskAddEditViewModel model)
        {
             var querry =  _iptaskrepository.GetById(model.Id);
            _iptaskrepository.Delete(querry);
            _uow.SaveChanges();
            
        }

        public List<TaskAddEditViewModel> GetAll()
        {
            var taskproject = _iptaskrepository.GetAll();
            var taskprojectSelect = taskproject.Select(x => new TaskAddEditViewModel
            {
                Title = x.Title,
                Description = x.Description,


            }).ToList();
            return taskprojectSelect;

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
       
       

      

        public void Update(TaskAddEditViewModel taskadd)
        {
            var update = _iptaskrepository.GetById(taskadd.Id);
            update.Title = taskadd.Title;
            update.Description = taskadd.Description;
            _uow.SaveChanges();
        }
    }
}
