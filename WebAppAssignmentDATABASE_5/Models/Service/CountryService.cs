using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.Repo;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _repo;

        public CountryService(ICountryRepo repo)
        {
            this._repo = repo;
        }
        public CountryViewModel Add(CreateCountryViewModel country)
        {
            Country createdCountry = _repo.Create(country.Name);
            return GetCountryViewModelFromEntity(createdCountry);
        }

        public CountriesViewModel All()
        {
            return new CountriesViewModel() { Countries = _repo.Read().Select(c => GetCountryViewModelFromEntity(c)).ToList() };
        }

        public CountryViewModel Edit(EditCountryViewModel country)
        {
            Country editedCountry = _repo.Read(country.Id);

            if (country.Name != null)
                editedCountry.Name = country.Name;

            editedCountry = _repo.Update(editedCountry);
            return GetCountryViewModelFromEntity(editedCountry);
        }

        public CountryViewModel FindBy(int id)
        {
            Country c = _repo.Read(id);
            return GetCountryViewModelFromEntity(c);
        }

        public bool Remove(int id)
        {
            return _repo.Delete(_repo.Read(id));
        }

        public CountryViewModel GetCountryViewModelFromEntity(Country country)
        {
            return new CountryViewModel() { Name = country.Name, Id = country.Id, Cities = country.Cities == null ? new List<CityViewModel>() : country.Cities.Select(s => new CityViewModel() { Name = s.Name, Id = s.Id }).ToList() };
        }
    }
}
