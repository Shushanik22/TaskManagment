using System.ComponentModel.DataAnnotations.Schema;
using TaskManagment.Data.Entities;
namespace TaskManagment.ViewModel
{
    public class WorkerAddEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public List <int> ProjectId { get; set; }
        public string LastName { get; set; }

        public string Position { get; set; }

      
    }
}
