using MatchmakingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchmakingService.DataContext
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext(DbContextOptions<UserInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
            UserInfos.Add(new UserInfo { Age = 20, FirstName = "Daniel", LastName = "Stuhr", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("9c10943b-b408-4200-b3a2-6fa2a5d96df8") });

            SaveChanges();
        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Activity> Activities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model is used to define a many to many relation in EF Core
            // Bridging tabel ActivityUser
            modelBuilder.Entity<ActivityUser>()
                .HasKey(activityUser => new { activityUser.ActivityId, activityUser.UserInfoId });
            modelBuilder.Entity<ActivityUser>()
                .HasOne(activityUser => activityUser.Activity)
                .WithMany(activity => activity.ActivityUsers)
                .HasForeignKey(actirityUser => actirityUser.UserInfoId);
            modelBuilder.Entity<ActivityUser>()
                .HasOne(activityUser => activityUser.UserInfo)
                .WithMany(userInfo => userInfo.ActivityUsers)
                .HasForeignKey(activityUser => activityUser.ActivityId);
        }

    }
}
