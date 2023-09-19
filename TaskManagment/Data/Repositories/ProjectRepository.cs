
using TaskManagment.Data.Repositories;
using TaskManagment.Data;
using TaskManagment.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Data.Entities;

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
            _context.SaveChanges();
           
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }


        public List<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project GetById(int id)
        {
            return _context.Projects.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       
    }
}
