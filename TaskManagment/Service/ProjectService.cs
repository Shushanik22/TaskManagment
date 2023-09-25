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


        public ProjectService(IProjectRepository projectRepository, IWorkerRepository workerRepository, IUnitOfWork uow)
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
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                TotalPercentage = project.TotalPercentage,
                Picture = project.Picture,
                WorkerIds = project.Workers.Select(w => w.Id).ToList(),

            };
        }
        public void Update(ProjectAddEditViewModel model)
        {
            var workers = _workerRepository.GetAll()
                .Where(p=> model.WorkerIds.Contains(p.Id)).ToList();
            var projectEntity = _iProjectRepository.GetById(model.Id);


            //projectEntity.Id = model.Id;
            projectEntity.Description = model.Description;
            projectEntity.TotalPercentage = model.TotalPercentage;
            projectEntity.Picture = model.Picture;
            projectEntity.Name = model.Name;

            
            
            projectEntity.Workers.Clear();
           
          
           
            projectEntity.Workers = workers;
            
            _uow.SaveChanges();


        }
        





        public List<ProjectListViewModel> GetAll()
        {

            var data = _iProjectRepository.GetAll();
            var projectlist = data.Select(x => new ProjectListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                WorkerName = String.Join(",", x.Workers.Select(x => x.FirstName))

            }).ToList();

            return projectlist;
        }


        public void Delete(ProjectAddEditViewModel model)
        {
            //var workers = _workerRepository.GetAll()
            //    .Where(p => model.WorkerIds.Contains(p.Id)).ToList();
            var querry = _iProjectRepository.GetById(model.Id);
            querry.Description = model.Description;
            querry.TotalPercentage = model.TotalPercentage;
            querry.Picture = model.Picture; 
            querry.Name = model.Name;
            _iProjectRepository.Delete(querry);
            _uow.SaveChanges();


        }
    }
}