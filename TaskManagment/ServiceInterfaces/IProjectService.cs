
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManagment.ViewModel;

namespace TaskManagment.Interface
{
    public interface IProjectService
    {
        void Add(ProjectAddEditViewModelcs projectadd);

        ProjectAddEditViewModelcs GetById(int id);

        void Update(ProjectAddEditViewModelcs projectadd);

        List<ProjectAddEditViewModelcs> GetAll();



    }
}
