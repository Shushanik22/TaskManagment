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

        public ProjectService(IProjectRepository projectRepository)
        {
            _iProjectRepository = projectRepository;
        }

        public void Add(ProjectAddEditViewModelcs projectadd)
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
        }
        public ProjectAddEditViewModelcs GetById(int id)
        {
            var project = _iProjectRepository.GetById(id);
            return new ProjectAddEditViewModelcs
            {
                Name = project.Name,
                Description = project.Description,
                TotalPercentage = project.TotalPercentage,
                Picture = project.Picture,

            };
           
        }

        public void Update(ProjectAddEditViewModelcs projectadd)
        {
           var project = _iProjectRepository.GetById(projectadd.Id);
           
            project.Picture = projectadd.Picture;
            project.Name = projectadd.Name;
            project.Description = projectadd.Description;
            project.TotalPercentage = projectadd.TotalPercentage;
            

            
        }

        public List<ProjectAddEditViewModelcs> GetAll()
        {
            var data = _iProjectRepository.GetAll();
            return data.Select(x => new ProjectAddEditViewModelcs
            {
               Name = x.Name,
               Description = x.Description,
               Picture = x.Picture,
               TotalPercentage = x.TotalPercentage,

                
            }).ToList();


        }

      
    }
}
