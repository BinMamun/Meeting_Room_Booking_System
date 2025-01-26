using MeetingRoomBookingSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingSystem.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
                                        <ApplicationUser, ApplicationRole, Guid,
                                        ApplicationUserClaim, ApplicationUserRole,
                                        ApplicationUserLogin, ApplicationRoleClaim,
                                        ApplicationUserToken>
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasData
                (
                    new ApplicationUser
                    {
                        Id = Guid.Parse("73EFA293-2C32-4746-9ECC-914AE3233251"),
                        UserName = "12345",
                        NormalizedUserName = "12345",
                        PasswordHash = "AQAAAAIAAYagAAAAEJvlP7iT7x94GkCsdqJRk0qGdGTywCXDjEP57/J0lodU+Z2mFSPoU2Trb20dkgYRQA==",
                        FullName = "Admin",
                        Department = "Administration",
                        SecurityStamp = "2176714C-1B4A-4EA1-ADAC-B34266A85BF2",
                        ConcurrencyStamp = "A6D75F7A-EB62-4389-8C2E-BF43AAAFA43D"
                    }
                );

            builder.Entity<ApplicationRole>()
                .HasData
                (
                    new ApplicationRole
                    {
                        Id = Guid.Parse("99C730F7-08F1-4C26-B721-B67FFAE26B94"),
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "AE06AECF-4D8D-4172-8B1B-38577DF9D250"
                    }
                );

            builder.Entity<ApplicationUserRole>()
                .HasData
                (
                    new ApplicationUserRole
                    {
                        RoleId = Guid.Parse("99C730F7-08F1-4C26-B721-B67FFAE26B94"),
                        UserId = Guid.Parse("73EFA293-2C32-4746-9ECC-914AE3233251")
                    }
                );

            base.OnModelCreating(builder);
        }

    }
}
