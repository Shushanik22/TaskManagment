using TaskManagment.Data.Entities;
namespace TaskManagment.Data.Repositories.Interfaces

{
    public interface IPTaskRepository
    {
        void Add(PTask task);
        PTask GetById(int id);
        List<PTask> GetAll();
        void Delete(PTask task);
        void SaveChanges();
    }
}
