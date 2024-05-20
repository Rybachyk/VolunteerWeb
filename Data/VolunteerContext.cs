using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VolunteerWeb.Models.DataBaseModels;
using Microsoft.Extensions.Configuration;

namespace VolunteerWeb.Data
{
    public class VolunteerContext : IdentityDbContext

    {
        private readonly IConfiguration _configuration;
        public VolunteerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<People> People { get; set; } // Набір даних користувачів
        public DbSet<News> News { get; set; } // Набір даних новин
        public DbSet<HelpRequest> HelpRequests { get; set; } // Набір даних запитів на допомогу

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HelpRequest>()
        //        .HasOne(g => g.People)
        //        .WithMany()
        //        .HasForeignKey(g => g.PeopleId);

        //    modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        //    modelBuilder.Entity< IdentityUserToken<string>>().HasNoKey();
        //}
    }
}