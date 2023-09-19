using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories;
using TaskManagment.Data.Repositories.Interfaces;

namespace TaskManagment.Data.Repositories
{
    public class PTaskRepository:IPTaskRepository
    {
        private readonly TaskContext _context;
        public PTaskRepository  (TaskContext context)
        {
            _context = context;
        }

        public void Add(PTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(PTask task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public List<PTask> GetAll()
        {
           return _context.Tasks.ToList() ;
            

        }

        public PTask GetById(int id)
        {
            return _context.Tasks.Find(id);
            
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
