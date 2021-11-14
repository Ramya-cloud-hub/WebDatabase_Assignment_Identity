using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public CityViewModel City { get; set; }

        public LanguagesViewModel Languages { get; set; }
    
        public string PhoneNr { get; set; }
        public string SocialSecurityNr { get; set; }

        public int Id { get; set; }

        public PersonViewModel()
        {

        }

        public PersonViewModel(string firstName, string lastName, CityViewModel City, string phoneNr, string socialSecurityNr)
        {

        }
    }
}
