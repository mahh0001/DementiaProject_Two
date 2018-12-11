using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models
{
    public class UserMatch
    {
        [Key]
        public int Id { get; set; }
        public long UserInfoId { get; set; }
        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }
        public long User2Id { get; set; }
        public virtual UserInfo User2 { get; set; }
        public bool FirstSelection { get; set; }
        public bool? IsAMatch { get; set; }
    }
}
