using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.Models
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public List<UserInfo> Users { get; set; }
    }
}
