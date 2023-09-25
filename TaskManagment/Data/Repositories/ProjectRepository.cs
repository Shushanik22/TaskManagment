
using TaskManagment.Data.Repositories;
using TaskManagment.Data;
using TaskManagment.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Data.Entities;
using TaskManagment.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace TaskManagment.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskContext _context;
        


        public ProjectRepository(TaskContext context)
        {
            _context = context;
        }
     
        public void Add(Project project)
        {
            _context.Projects.Add(project);
           
           
        }
        //public void Update(Project project)
        //{
        //    var entity = _context.Projects.FirstOrDefault(p => p.Id == project.Id);
        //    _context.Projects.Update(entity);
        //}

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
            
        }


        public List<Project> GetAll()
        {
            return _context.Projects.Include(p=>p.Workers).ToList();
        }

        public Project GetById(int id)
        {
            return _context.Projects.Include(p => p.Workers).
                FirstOrDefault(p => p.Id == id);
        }

        
    }
}
