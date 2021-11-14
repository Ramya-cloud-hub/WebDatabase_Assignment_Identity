using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get { return name; } set { name = value; } }
        private string name;

        public List<City> Cities { get { return cities; } set { cities = value; } }
        private List<City> cities;

        public Country()
        {

        }

        public Country(string name, List<City> cities)
        {
            this.Name = name;
            this.Cities = cities;
        }

        public void AddCity(City city)
        {
            if(Cities == null)
            {
                Cities = new List<City>();
            }

            city.Country = this;
            Cities.Add(city);
            city.CountryId = this.Id;
        }
    }
}
