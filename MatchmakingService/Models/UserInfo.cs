using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models
{
    public class UserInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        public byte[] Picture { get; set; }
    }
}
