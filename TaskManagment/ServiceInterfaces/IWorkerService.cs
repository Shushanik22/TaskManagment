using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IWorkerService
    {
       // void Add(WorkerAddEditViewModel workeradd);

       // WorkerAddEditViewModel GetById(int id);

       // void Update(WorkerAddEditViewModel workeradd);

        List<WorkerAddEditViewModel> GetAll();
    }
}
