using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models.DataTransferObjects
{
    public class MatchDTO
    {
        public Guid User1 { get; set; }
        public Guid User2 { get; set; }
        public bool Match { get; set; }
    }
}
