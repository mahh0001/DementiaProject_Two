using System.ComponentModel.DataAnnotations;

namespace DementiaProject_Two.Models.User
{
    public class UserInformationModel
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        //Fremmednøgle til Identity
        [Key]
        public string Email { get; set; }
    }
}
