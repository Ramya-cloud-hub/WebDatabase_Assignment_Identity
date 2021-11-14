using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data.Exceptions;

namespace WebAppAssignmentDATABASE_5.Models.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
      
        private static int idCounter;
        private static List<Person> people = new List<Person>()
        {
             new Person("Ramya", "Gowda", 0, "034-3572-566", ++idCounter, "1"),
            new Person("Srinivas", "Gowda", 0, "034-3572-566", ++idCounter, "2"),
            new Person("Mamatha", "koppolu", 0, "034-3572-566", ++idCounter, "3"),
            new Person("Kishore", "hjtyu", 0, "034-3572-566", ++idCounter, "4")
           
        };

        public Person Create(string firstName, string lastName, int cityId, string phoneNr, string socialSecurityNr, List<Language> languages)
        {
            Person person = new Person(firstName, lastName, cityId, phoneNr, ++idCounter, socialSecurityNr);
            people.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {
            return people.Remove(person);
        }

        public List<Person> Read()
        {
            return people;
        }

        public Person Read(int id)
        {
            Person person = people.Find(p => p.Id == id);
            
            if(person != null)
            {
                return person;
            }

            throw new EntityNotFoundException("Person with id " + id + " not found");
        }

        public Person Update(Person person)
        {
            Person p = Read(person.Id);

            if (person.FirstName != null)
                p.FirstName = person.FirstName;
            if (person.LastName != null)
                p.LastName = person.LastName;
            if (person.City != null)
                p.City = person.City;
            if (person.PhoneNr != null)
                p.PhoneNr = person.PhoneNr;

            return p;
        }
    }
}
