using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models
{
    public class UserMatch
    {
        public long Id { get; set; }
        public Guid User1Id { get; set; }
        public bool User1Agree { get; set; }
        public Guid User2Id { get; set; }
        public bool User2Agree { get; set; }
    }
}
