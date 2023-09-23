using TaskManagment.Data.Entities;
using TaskManagment.ViewModel;

namespace TaskManagment.Data.Repositories.Interfaces

{
    public interface IProjectTaskRepository
    {
        void Add(ProjectTask task);
        ProjectTask GetById(int id);
        List<ProjectTask> GetAll(TaskAddEditViewModel model);
        void Delete(ProjectTask task);
      
    }
}
