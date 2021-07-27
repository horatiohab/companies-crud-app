using CompaniesApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company")
                .HasData(
                    new Company { CompanyId = 1, Name = "Microsoft", Email = "contact@microsoft.com", Website = "microsoft.com", Logo = @"\images\Microsoft_logo.png" },
                    new Company { CompanyId = 2, Name = "Google", Email = "contact@google.com", Website = "google.com", Logo = @"\images\Google_logo.png" },
                    new Company { CompanyId = 3, Name = "Apple", Email = "contact@apple.com", Website = "apple.com", Logo = @"\images\Apple_logo.png" },
                    new Company { CompanyId = 4, Name = "Amazon", Email = "contact@amazon.com", Website = "amazon.com", Logo = @"\images\Amazon_logo.png" },
                    new Company { CompanyId = 5, Name = "Facebook", Email = "contact@facebook.com", Website = "facebook.com", Logo = @"\images\Facebook_logo.png" },
                    new Company { CompanyId = 6, Name = "Netflix", Email = "contact@netflix.com", Website = "netflix.com", Logo = @"\images\Netflix_logo.png" }
                );


            modelBuilder.Entity<Employee>().ToTable("Employee")
                .HasData(
                    new Employee { EmployeeId = 1, FirstName = "Ringo", LastName = "Star", Email = "ringo@star.com", PhoneNumber = "001987621", CompanyId = 1 },
                    new Employee { EmployeeId = 2, FirstName = "Paul", LastName = "McCartney", Email = "paul@mccartney.com", PhoneNumber = "001987622", CompanyId = 2 },
                    new Employee { EmployeeId = 3, FirstName = "George", LastName = "Harrison", Email = "george@harrison.com", PhoneNumber = "001987623", CompanyId = 3 },
                    new Employee { EmployeeId = 4, FirstName = "John", LastName = "Lennon", Email = "john@lennon.com", PhoneNumber = "001987624", CompanyId = 4 },
                    new Employee { EmployeeId = 5, FirstName = "Ozzy", LastName = "Osbourne", Email = "ozzy@osbourne.com", PhoneNumber = "001987625", CompanyId = 5 },
                    new Employee { EmployeeId = 6, FirstName = "Benedict", LastName = "Cumberbatch", Email = "benedict@cumberbatch.com", PhoneNumber = "001987626", CompanyId = 6 }
                );
        }
    }
}
