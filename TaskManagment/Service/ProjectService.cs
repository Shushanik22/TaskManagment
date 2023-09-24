using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManagment.Data;
using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;
using TaskManagment.ViewModel;


namespace TaskManagment.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _iProjectRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _uow;

        public ProjectService(IProjectRepository projectRepository, IWorkerRepository workerRepository,IUnitOfWork uow)
        {
            _iProjectRepository = projectRepository;
            _workerRepository = workerRepository;
            _uow = uow;
             
    }

        public void AddEdit(ProjectAddEditViewModel projectaddedit)
        {
            var workers = projectaddedit.WorkerIds.Select(
                p => new Worker { Id = p }).ToList();
            
            var entity = _iProjectRepository.GetById(projectaddedit.Id);
            if (entity != null)
            {
                entity.Description = projectaddedit.Description;
                entity.Name = projectaddedit.Name;
                entity.Picture = projectaddedit.Picture;
                entity.TotalPercentage = projectaddedit.TotalPercentage;

            }
            Project project = new Project
            {
                Name = projectaddedit.Name,
                Description = projectaddedit.Description,
                TotalPercentage = projectaddedit.TotalPercentage,
                Picture = projectaddedit.Picture,
                
                
                // PTaskID
                // WorkerID relation

            };
            

            _workerRepository.AttachRange(workers);
            project.Workers = workers;
            _iProjectRepository.Add(project);
            _uow.SaveChanges();
        }
        public ProjectAddEditViewModel GetById(int id)
        {
            var project = _iProjectRepository.GetById(id);
            return new ProjectAddEditViewModel
            {
                Name = project.Name,
                Description = project.Description,
                TotalPercentage = project.TotalPercentage,
                Picture = project.Picture,
                WorkerIds = project.Workers.Select(c => c.Id).ToList(),

            };
           
        }

        //public void Update(ProjectAddEditViewModel projectadd)
        //{
        //    var workers = projectadd.WorkerIds.Select(
        //       p => new Worker { Id = p }).ToList();
        //    var project = _iProjectRepository.GetById(projectadd.Id);
        //    project.Picture = projectadd.Picture;
        //    project.Name = projectadd.Name;
        //    project.Description = projectadd.Description;
        //    project.TotalPercentage = projectadd.TotalPercentage;
        //    foreach (var item in project.Workers)
        //    {
        //        _workerRepository.ChangeTracking(item);
        //    }
        //    project.Workers.Clear();
        //    project.Workers = workers;
        //    _workerRepository.AttachRange(workers);
        //    _uow.SaveChanges();



        //}

        public List<ProjectListViewModel> GetAll()
        {
            
            var data = _iProjectRepository.GetAll();
            var projectlist= data.Select(x => new ProjectListViewModel
            {
               Name = x.Name,
               WorkerName = String.Join(",", x.Workers?.Select(x => x.FirstName))

            }).ToList();

            return projectlist;
        }

        
    }
}
