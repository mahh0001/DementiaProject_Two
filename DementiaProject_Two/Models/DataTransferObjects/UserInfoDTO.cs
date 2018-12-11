using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.Models.DataTransferObjects
{
    public class UserInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        //Fremmednøgle til Identity
        public Guid IdentityFK { get; set; }
    }
}
