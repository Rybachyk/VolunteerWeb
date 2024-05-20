using Microsoft.EntityFrameworkCore;
using VolunteerWeb.Models.DataBaseModels;
using Microsoft.Extensions.Configuration;

namespace VolunteerWeb._DataAccess
{
    public class VolonteerContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public VolonteerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; } // Набір даних користувачів
        public DbSet<News> News { get; set; } // Набір даних новин
        public DbSet<HelpRequest> HelpRequests { get; set; } // Набір даних запитів на допомогу
        public DbSet<Donation> Donations { get; set; } // Набір даних пожертв
        public DbSet<Administrator> Administrators { get; set; } // Набір даних адміністраторів

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Database=VolunteerWeb;Username=postgres;Password=12345678");
        //}
    }
}
