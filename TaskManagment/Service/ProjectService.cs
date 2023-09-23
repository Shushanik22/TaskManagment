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

        public void Add(ProjectAddEditViewModel projectadd)
        {
            Project project = new Project
            {
                Name = projectadd.Name,
                Description = projectadd.Description,
                TotalPercentage = projectadd.TotalPercentage,
                Picture = projectadd.Picture,
                
                
                // PTaskID
                // WorkerID relation

            };
            var workers = projectadd.WorkerIds.Select(
                p => new Worker { Id = p }).ToList();

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

        public void Update(ProjectAddEditViewModel projectadd)
        {
            var workers = projectadd.WorkerIds.Select(
               p => new Worker { Id = p }).ToList();
            var project = _iProjectRepository.GetById(projectadd.Id);
            project.Picture = projectadd.Picture;
            project.Name = projectadd.Name;
            project.Description = projectadd.Description;
            project.TotalPercentage = projectadd.TotalPercentage;
            foreach (var item in project.Workers)
            {
                _workerRepository.ChangeTracking(item);
            }
            project.Workers.Clear();
            project.Workers = workers;
            _workerRepository.AttachRange(workers);
            _uow.SaveChanges();



        }

        public List<ProjectListViewModel> GetAll(ProjectListViewModel projectmodel)
        {
            var data = _iProjectRepository.GetAll(projectmodel);
            var projectlist= data.Select(x => new ProjectListViewModel
            {
               Name = x.Name,
               WorkerName = String.Join(",", x.Workers.Select(x => x.FirstName))

            }).ToList();

            return projectlist;
        }

        
    }
}
