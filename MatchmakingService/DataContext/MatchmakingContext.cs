using MatchmakingService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MatchmakingService.DataContext
{
    public class MatchmakingContext : DbContext
    {
        public MatchmakingContext(DbContextOptions<MatchmakingContext> options) : base(options)
        {
            Database.EnsureCreated();
            UserInfos.Add(new UserInfo { Age = 20, FirstName = "Daniel", LastName = "Stuhr", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("9c10943b-b408-4200-b3a2-6fa2a5d96df8") });
            UserInfos.Add(new UserInfo { Age = 22, FirstName = "Rasmus", LastName = "Bak", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("9c10943b-b408-8300-b3a2-6fa2a5d96df8")});
            UserInfos.Add(new UserInfo { Age = 36, FirstName = "Jesper", LastName = "Madsen", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("8c20943b-b408-8300-b3a2-6fa2a5d96df8")});
            UserInfos.Add(new UserInfo { Age = 24, FirstName = "Hafsteinn", LastName = "Ragnarsson", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("8c20947c-b408-8300-b3a2-6fa2a5d96df8")});
            UserInfos.Add(new UserInfo { Age = 25, FirstName = "Mathias", LastName = "Nabe", Gender = "Male", ZipCode = 5000, IdentityFK = Guid.Parse("8c20947c-b408-8300-b3a2-6fa2a5d96df1") });
            SaveChanges();
        }
        public DbSet<UserInfo> UserInfos { get; set; }
        //public DbSet<Activity> Activities { get; set; }
        public DbSet<UserMatch> Matches { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Model is used to define a many to many relation in EF Core
        //    // Bridging tabel ActivityUser
        //    modelBuilder.Entity<ActivityUser>()
        //        .HasKey(activityUser => new { activityUser.ActivityId, activityUser.UserInfoId });
        //    modelBuilder.Entity<ActivityUser>()
        //        .HasOne(activityUser => activityUser.Activity)
        //        .WithMany(activity => activity.ActivityUsers)
        //        .HasForeignKey(actirityUser => actirityUser.UserInfoId);
        //    modelBuilder.Entity<ActivityUser>()
        //        .HasOne(activityUser => activityUser.UserInfo)
        //        .WithMany(userInfo => userInfo.ActivityUsers)
        //        .HasForeignKey(activityUser => activityUser.ActivityId);

        //}

    }
}
