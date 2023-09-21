using System.ComponentModel.DataAnnotations.Schema;
using TaskManagment.Data.Entities;
using TaskManagment.EnumFolder;

namespace TaskManagment.ViewModel
{
    public class TaskAddEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WorkerId { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
        public int ProjectId { get; set; }
        public DateTime DueDate { get; set; }



    }
}
