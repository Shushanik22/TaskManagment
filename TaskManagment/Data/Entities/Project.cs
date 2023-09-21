using TaskManagment.EnumFolder;
namespace TaskManagment.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public ICollection<PTask> pTasks { get; set; }
        public ICollection <Worker> Workers { get; set; }

        public int pTasKID { get; set; }
        public RoleEnum Role { get; set; }

      
       
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public decimal TotalPercentage { get; set; }
       

    }
}