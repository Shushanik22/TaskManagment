
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IProjectService
    {
        void AddEdit(ProjectAddEditViewModel projectadd);

        ProjectAddEditViewModel GetById(int id);

       //void Update(ProjectAddEditViewModel projectadd);

        List<ProjectListViewModel> GetAll();
        
    }
}
