using Microsoft.EntityFrameworkCore;
using TaskManagment.Data.Entities;
namespace TaskManagment.Data
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> opt):base(opt)
        {

        }
        public DbSet<Project> Projects { get;set; }

        public DbSet<Worker> Workers { get;set;}
        public DbSet<PTask> Tasks { get; set; }

        

    }
}
