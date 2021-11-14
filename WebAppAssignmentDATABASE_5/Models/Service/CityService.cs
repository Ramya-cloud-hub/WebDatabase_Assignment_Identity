using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.Repo;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _repo;

        public CityService(ICityRepo repo)
        {
            this._repo = repo;
        }
        public CityViewModel Add(CreateCityViewModel city)
        {
            City createdCity = _repo.Create(city.CountryId, city.Name);
            return GetViewModelFromEntity(createdCity);
        }

        public CitiesViewModel All()
        {
            return new CitiesViewModel() { Cities = _repo.Read().Select(c => GetViewModelFromEntity(c)).ToList() };
        }

        public CityViewModel Edit(EditCityViewModel city)
        {
            City c = _repo.Read(city.Id);

            if (city.Name != null)
                c.Name = city.Name;
            if (city.CountryId > 0)
                c.CountryId = city.CountryId;

            c = _repo.Update(c);

            return GetViewModelFromEntity(c);
        }

        public CityViewModel FindBy(int id)
        {
            return GetViewModelFromEntity(_repo.Read(id));
        }

        public bool Remove(int id)
        {

            return _repo.Delete(_repo.Read(id));

        }

        private CityViewModel GetViewModelFromEntity(City city)
        {
            return new CityViewModel() { Name = city.Name, Country = new CountryViewModel() { Name = city.Country.Name }, Id = city.Id };
        }
    }
}
