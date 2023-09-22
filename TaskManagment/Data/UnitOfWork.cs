namespace TaskManagment.Data
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly TaskContext _context;
        public UnitOfWork(TaskContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}
