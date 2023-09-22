using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IPTaskService
    {
        void Add(TaskAddEditViewModel taskadd);

        TaskAddEditViewModel GetById(int id);

        void Update(TaskAddEditViewModel taskadd);

        List<TaskAddEditViewModel> GetAll();

    }
}
