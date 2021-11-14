using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data;
using WebAppAssignmentDATABASE_5.Data.Exceptions;

namespace WebAppAssignmentDATABASE_5.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleContext _context;

        public DatabasePeopleRepo(PeopleContext context)
        {
            _context = context;
        }

        public Person Create(string firstName, string lastName, int cityId, string phoneNr, string socialSecurityNr, List<Language> languages)
        {
            Person person = new Person(firstName, lastName, cityId, phoneNr, socialSecurityNr);

            if(languages != null)
            {
                foreach (Language language in languages)
                {
                    person.AddLanguage(language);
                }
            }
           
            _context.People.Add(person);
            _context.SaveChanges();

            return Read(person.Id);
        }

        public bool Delete(Person person)
        {
            try
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public List<Person> Read()
        {
            return _context.People.Include(p => p.Languages).ThenInclude(lp => lp.Language).Include(p => p.City).ThenInclude(c => c.Country).ToList();
        }

        public Person Read(int id)
        {
            Person person = _context.People.Include(p => p.Languages).ThenInclude(lp => lp.Language).Include(p => p.City).ThenInclude(c => c.Country).FirstOrDefault(p => p.Id == id);

            if (person == null)
                throw new EntityNotFoundException("Person with id " + id + " not found");

            return person;
        }

        public Person Read(string socialSecurityNr)
        {
            Person person = _context.People.First(p => p.SocialSecurityNr.Equals(socialSecurityNr));

            if (person == null)
                throw new EntityNotFoundException("Person with SSN " + socialSecurityNr + " not found");

            return person;

        }

        public Person Update(Person person)
        {
            Person p = Read(person.Id);

            var properties = person.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].GetValue(person) != null)
                {
                    p.GetType().GetProperty(properties[i].Name).SetValue(p, properties[i].GetValue(person));

                }
            }

            _context.Update(p);
            _context.SaveChanges();

            return Read(person.Id);
        }
    }
}
