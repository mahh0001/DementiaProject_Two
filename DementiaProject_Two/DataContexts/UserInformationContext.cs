using DementiaProject_Two.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.DataContexts
{
    public class UserInformationContext : DbContext
    {
        public UserInformationContext(DbContextOptions<UserInformationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserInformationModel> UserInformations { get; set; }
    }
}
