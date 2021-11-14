using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public interface ICityService
    {
        CityViewModel Add(CreateCityViewModel city);

        CitiesViewModel All();

        CityViewModel FindBy(int id);

        CityViewModel Edit(EditCityViewModel city);

        bool Remove(int id);
    }
}
