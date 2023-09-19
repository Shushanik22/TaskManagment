using Microsoft.Build.Evaluation;

namespace TaskManagment.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        void Add(Project project);
        Project GetById(int id);
        List<Project> GetAll();
        void Delete(Project project);
        void SaveChanges();
    }
}
