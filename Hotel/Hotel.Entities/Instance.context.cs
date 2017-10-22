using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public partial class InstanceEntities : DbContext
    {
        public InstanceEntities(DbContextOptions<InstanceEntities> options) : base(options)
        {
        }
        public DbSet<Claim> Claim { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLoginToken> UserLoginToken { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<TopSlide> TopSlide { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomImage> RoomImage { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<UserFeedback> UserFeedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasMany(x => x.UserProfiles)
                 .WithOne(x => x.User)
                 .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserLoginTokens)
                .WithOne(x => x.User)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Claim>()
                .HasMany(x => x.RoleClaims)
                .WithOne(x => x.Claim)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Role>()
                .HasMany(x => x.RoleClaims)
                .WithOne(x => x.Role)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasOne(x => x.CompanyInfo)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.TopSlides)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Articles)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Services)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.UserFeedbacks)
                .WithOne(x => x.Company)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            modelBuilder.Entity<Room>()
                .HasMany(x => x.RoomImages)
                .WithOne(x => x.Room)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);



        }
    }
}
