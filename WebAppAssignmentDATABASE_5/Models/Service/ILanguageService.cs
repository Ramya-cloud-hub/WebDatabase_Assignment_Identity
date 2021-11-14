using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public interface ILanguageService
    {
        LanguageViewModel Add(CreateLanguageViewModel language);

        LanguagesViewModel All();

        LanguageViewModel FindBy(int id);

        LanguageViewModel Edit(int id, Language language);

        bool Remove(int id);
    }
}
