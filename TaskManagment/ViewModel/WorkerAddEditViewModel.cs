using System.ComponentModel.DataAnnotations.Schema;
using TaskManagment.Data.Entities;
namespace TaskManagment.ViewModel
{
    public class WorkerAddEditViewModel
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        public int ProjectID { get; set; }
        public string LastName { get; set; }

        public string Position { get; set; }

        public ContactInformation ContactInformation { get; set; }
    }
}
