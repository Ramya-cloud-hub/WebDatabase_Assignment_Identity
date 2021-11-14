using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public interface ICountryService
    {
        CountryViewModel Add(CreateCountryViewModel country);

        CountriesViewModel All();

        CountryViewModel FindBy(int id);

        CountryViewModel Edit(EditCountryViewModel country);

        bool Remove(int id);
        
    }
}
