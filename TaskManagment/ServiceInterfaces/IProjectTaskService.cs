using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IProjectTaskService
    {
        void Add(TaskAddEditViewModel taskadd);

        TaskAddEditViewModel GetById(int id);

        void Update(TaskAddEditViewModel taskadd);

        List<TaskAddEditViewModel> GetAll();

        void Delete(TaskAddEditViewModel model);

    }
}
