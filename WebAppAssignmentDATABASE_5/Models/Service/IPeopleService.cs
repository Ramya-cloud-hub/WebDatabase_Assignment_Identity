using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public interface IPeopleService
    {
        PersonViewModel Add(CreatePersonViewModel person);

        PeopleViewModel All();

        PeopleViewModel FindBy(PeopleViewModel search);

        PersonViewModel FindBy(int id);

        PersonViewModel Edit(int id, EditPersonViewModel person);

        bool Remove(int id);

        PeopleViewModel SortBy(string fieldName, bool alphabetical);
    }
}
