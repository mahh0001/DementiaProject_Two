using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models
{
    public class UserMatch
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        public virtual UserInfo User1 { get; set; }
        public Guid User2Id { get; set; }
        public virtual UserInfo User2 { get; set; }
        public bool FirstSelection { get; set; }
        public bool? IsAMatch { get; set; }
    }
}
