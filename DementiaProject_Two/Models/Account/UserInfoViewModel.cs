using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.Models
{
    // Denne implementering er kun til at teste viewet
    public class UserInfoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(1)]
        public string FirstName { get; set; }
        [MinLength(1)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        public byte[] Picture { get; set; }
        public List<string> PreferedActivities { get; set; }
        //Fremmednøgle til Identity
        public Guid IdentityFK { get; set; }
    }
}
