namespace TaskManagment.Data.Entities
{
    public class PTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string WorkerComment { get; set; }

        public string Description { get; set; }

        public enum Level;

        public string Duration { get; set; }

        public string DonePercentage { get; set; }
 
        public string UserComment { get; set; }

        

    }
}
