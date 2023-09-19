using System.ComponentModel.DataAnnotations;

namespace TaskManagment
{
    public class ContactInformation
    {
        [Key]
        public int ContactID { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

      
    }
}
