using System.ComponentModel.DataAnnotations.Schema;

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

        public enum Level
        {
            Easy = 1,
            Medium = 2,
            Hard = 3,
        }

        public string Duration { get; set; }

        public string DonePercentage { get; set; }
 
        public string UserComment { get; set; }

        

    }
}
