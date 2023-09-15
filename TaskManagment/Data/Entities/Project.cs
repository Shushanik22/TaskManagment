namespace TaskManagment.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public enum RoleEnum;
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public decimal TotalPercentage { get; set; }
       

    }
}