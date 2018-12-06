using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.Models.Matching
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        //public byte[] Picture { get; set; }
        //Fremmednøgle til Identity
        public Guid IdentityFK { get; set; }
        //public List<ActivityUser> ActivityUsers { get; set; }
        //public List<UserMatch> Matches { get; set; } => this shouldnt be needed up in here. up in here.
    }
}
