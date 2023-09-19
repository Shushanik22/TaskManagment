using TaskManagment.Data.Entities;

namespace TaskManagment.Data.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        void Add(Worker worker);
        Worker GetById(int id);
        List<Worker> GetAll();
        void Delete(Worker worker);
        void SaveChanges();
    }
}
