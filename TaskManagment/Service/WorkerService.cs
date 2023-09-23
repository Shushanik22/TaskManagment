using Microsoft.CodeAnalysis;
using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories.Interfaces;
using TaskManagment.Interface;
using TaskManagment.ViewModel;

namespace TaskManagment.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository=workerRepository;
        }

   

        public List<WorkerAddEditViewModel> GetAll()
        {
            var data = _workerRepository.GetAll();
            var workers= data.Select(x => new WorkerAddEditViewModel
            {
               FirstName = x.FirstName,
               Id = x.Id,
            }).ToList();
            return workers;
        }

        
    }
}
