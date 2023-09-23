using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.ViewModel;

namespace TaskManagment.Data.Repositories
{
    public class ProjectTaskRepository:IProjectTaskRepository
    {
        private readonly TaskContext _context;
        
        public ProjectTaskRepository  (TaskContext context)
        {
            _context = context;
        }

        public void Add(ProjectTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(ProjectTask task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public List<ProjectTask> GetAll(TaskAddEditViewModel model)
        {
           return _context.Tasks.ToList() ;
            

        }

        public ProjectTask GetById(int id)
        {
            return _context.Tasks.Find(id);
            
        }

        
    }
}
