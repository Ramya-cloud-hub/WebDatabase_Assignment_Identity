using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class Person
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get { return firstName; } set { firstName = value; } }
        private string firstName;
        [Required]
        [MaxLength(100)]
        public string LastName { get { return lastName; } set { lastName = value; } }
        private string lastName;
        [Required]
        public City City { get { return city; } set { city = value; } }
        private City city;

        public int CityId { get { return cityId; } set { cityId = value; } }
        private int cityId;

        [Phone]
        public string PhoneNr { get { return phoneNr; } set { phoneNr = value; } }
        private string phoneNr;


        [Required]
        public string SocialSecurityNr { get { return socialSecurityNr; } set { socialSecurityNr = value; } }
        private string socialSecurityNr;

        [Key]
        public int Id { get { return id; } set { id = value; } }
        private int id;

        public List<LanguagePerson> Languages { get { return languages; } set { languages = value; } }
        private List<LanguagePerson> languages;

        public Person() { }
        public Person(string firstName, string lastName, 
            int cityId, string phoneNr, int id, string SSN) : this(id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CityId = cityId;
            this.PhoneNr = phoneNr;
            this.SocialSecurityNr = SSN;
        } 
        public Person(string firstName, string lastName, 
            City city, string phoneNr, string SSN) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.PhoneNr = phoneNr;
            this.SocialSecurityNr = SSN;
        } 
        public Person(string firstName, string lastName, 
            int cityId, string phoneNr, string SSN) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CityId = cityId;
            this.PhoneNr = phoneNr;
            this.SocialSecurityNr = SSN;
        }
        public Person(int id)
        {
            this.Id = id;
        }

        public void AddLanguage(Language language)
        {
            if (this.Languages == null)
                this.Languages = new List<LanguagePerson>();

            this.Languages.Add(new LanguagePerson() { LanguageId = language.Id });
        }
    }
}
