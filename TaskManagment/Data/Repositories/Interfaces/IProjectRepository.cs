using TaskManagment.Data.Entities;
using TaskManagment.ViewModel;

namespace TaskManagment.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        void Add(Project project);
        //void Update(Project project);

        Project GetById(int id);
        List<Project> GetAll();
        void Delete(Project project);

        
      
       
    }
}
