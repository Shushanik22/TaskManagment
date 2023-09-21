
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IProjectService
    {
        void Add(ProjectAddEditViewModel projectadd);

        ProjectAddEditViewModel GetById(int id);

        void Update(ProjectAddEditViewModel projectadd);

        List<ProjectAddEditViewModel> GetAll();



    }
}
