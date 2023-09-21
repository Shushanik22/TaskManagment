using System.ComponentModel.DataAnnotations.Schema;
using TaskManagment.EnumFolder;
namespace TaskManagment.Data.Entities
{
    public class PTask
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string WorkerComment { get; set; }
        [ForeignKey("Worker")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public string Description { get; set; }

        public Level Level { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string Duration { get; set; }

        public string DonePercentage { get; set; }

        public string UserComment { get; set; }



    }
}
