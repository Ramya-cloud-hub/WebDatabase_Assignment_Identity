using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models;

namespace WebAppAssignmentDATABASE_5.Data
{
    public class PeopleContext : DbContext
    {
   
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasIndex(p => p.SocialSecurityNr).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<LanguagePerson>().HasKey(lp => new { lp.PersonId, lp.LanguageId });

            Country sweden = new Country() { Name = "Sweden", Id = 1 };
            Country india = new Country() { Name = "India", Id = 2 };
            Country srilanka = new Country() { Name = "Srikanka", Id = 3 };
            Country denmark = new Country() { Name = "Denmark", Id = 4 };
            Country paris = new Country() { Name = "Paris", Id = 5 };

            City stockholm = new City() { Name = "Stockholm", Id = 1, CountryId = sweden.Id };
            City goteborg = new City() { Name = "Göteborg", Id = 2, CountryId = sweden.Id };
            City newDelhi = new City() { Name = "New Delhi", Id = 3, CountryId = india.Id };
            City bengalore = new City() { Name = "bengalore", Id = 4, CountryId = india.Id };
            City colombo = new City() { Name = "Colombo", Id = 5, CountryId = srilanka.Id };
            City mumbai = new City() { Name = "Mumbai", Id = 6, CountryId = india.Id };
            City copenhegan = new City() { Name = "Copenhegan", Id = 7, CountryId = denmark.Id };

            Person ramya = new Person() { FirstName = "Ramya", LastName = "Gowda", PhoneNr = "034-4242-657", CityId = bengalore.Id, Id = 1, SocialSecurityNr = "19894574666" };
            Person chandra = new Person() { FirstName = "Chandra", LastName = "Janaki", PhoneNr = "098-4763-578", CityId = colombo.Id, Id = 2, SocialSecurityNr = "19894574662" };
            Person ching = new Person() { FirstName = "Ching", LastName = "chai", PhoneNr = "077-2352-287", Id = 3, CityId = goteborg.Id, SocialSecurityNr = "19894574663" };
            Person mamatha = new Person() { FirstName = "Mamatha", LastName = "kishore", PhoneNr = "098-4278-264", Id = 4, CityId = mumbai.Id, SocialSecurityNr = "19894574664" };

            Language swedish = new Language() { Name = "Swedish", Id = 1 };
            Language indian = new Language() { Name = "Kannada", Id = 2 };
            Language srilankan = new Language() { Name = "Tamil", Id = 3 };
            Language denmarkan = new Language() { Name = "Denish", Id = 4 };

          

            modelBuilder.Entity<Language>().HasData(swedish, indian, srilankan, denmark);
            modelBuilder.Entity<Person>().HasData(ramya, chandra, ching, mamatha);
            modelBuilder.Entity<LanguagePerson>().HasData(new LanguagePerson(){ LanguageId = 1, PersonId = 1 }, new LanguagePerson() { LanguageId = 2, PersonId = 1 }, new LanguagePerson() { LanguageId = 1, PersonId = 2 }, new LanguagePerson() { LanguageId = 1, PersonId = 3 }, new LanguagePerson() { LanguageId = 1, PersonId = 4 }, new LanguagePerson() { LanguageId = 2, PersonId = 4 }, new LanguagePerson() { LanguageId = 3, PersonId = 4 });

            modelBuilder.Entity<City>().HasData(stockholm, goteborg, newDelhi, bengalore, colombo, mumbai, copenhegan);
            modelBuilder.Entity<Country>().HasData(sweden, india, srilanka, denmark, paris);
           

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguagePerson> LanguagePerson { get; set; }
    }
}
