using DementiaProject_Two.Models.Account;
using Microsoft.EntityFrameworkCore;

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
