namespace TaskManagment.Data.Entities
{
    public class Worker
    {
        public int Id { get; set; } 

        public string FirstName { get; set; }    

        public string LastName { get; set; }

        public string Position { get; set; }

        public ContactInformation ContactInformation { get; set; }



    }
}
