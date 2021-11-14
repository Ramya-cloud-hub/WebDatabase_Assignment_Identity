using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data;
using WebAppAssignmentDATABASE_5.Data.Exceptions;

namespace WebAppAssignmentDATABASE_5.Models.Repo
{
    public class DatabaseCityRepo : ICityRepo
    {
        private readonly PeopleContext _context;

        public DatabaseCityRepo(PeopleContext context)
        {
            _context = context;
        }
        public City Create(int countryId, string cityName)
        {
            City city = new City() { CountryId = countryId, Name = cityName };
            _context.Cities.Add(city);
            _context.SaveChanges();

            return Read(city.Id);
        }

        public bool Delete(City city)
        {
            try
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
        

            return true;
        }

        public List<City> Read()
        {
            return _context.Cities.Include(c => c.Country).ToList(); 
        }

        public City Read(int id)
        {
            City city = _context.Cities.Include(c => c.Country).FirstOrDefault(c => c.Id == id);

            if(city == null)
            {
                throw new EntityNotFoundException("City with id " + id + " cannot be found");
            }

            return city;

        }

        public City Update(City city)
        {
            _context.Attach(city);
            _context.SaveChanges();

            return Read(city.Id);
        }
    }
}
