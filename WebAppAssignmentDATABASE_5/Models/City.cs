using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get { return name; } set { name = value; } }
        private string name;

        [Required]
        public Country Country { get { return country; } set { country = value; } }
        private Country country;

        public int CountryId { get; set; }

        public List<Person> People { get { return people; } set { people = value; } }
        private List<Person> people;

        public City()
        {

        }

        public City(string name, Country country, List<Person> people)
        {
            this.Name = name;
            this.Country = country;
            this.People = people;
        }

        public void AddPerson(Person person)
        {
            if(this.People == null)
            {
                People = new List<Person>();
            }

            People.Add(person);
            person.City = this;
            person.CityId = this.Id;

        }
    }
}
