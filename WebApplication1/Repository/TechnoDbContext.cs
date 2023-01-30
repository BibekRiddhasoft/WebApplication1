using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class TechnoDbContext : DbContext
    {
        public TechnoDbContext(DbContextOptions dbContext) : base(dbContext)
        {

        }
        public TechnoDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("RTechDemoContext");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        public DbSet<SignUp> SignUp { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }



    }


    public class SignUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string CountryCode { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
    }


}
