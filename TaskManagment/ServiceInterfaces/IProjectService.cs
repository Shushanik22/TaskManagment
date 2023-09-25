
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IProjectService
    {
        void Add(ProjectAddEditViewModel project);

        void Delete(ProjectAddEditViewModel project);

        ProjectAddEditViewModel GetById(int  id);

        void Update(ProjectAddEditViewModel model);

        List<ProjectListViewModel> GetAll();
        
    }
}
