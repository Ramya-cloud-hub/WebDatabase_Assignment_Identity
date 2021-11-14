using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class EditPersonViewModel
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int CityId { get; set; }

        [Phone]
        public string PhoneNr { get; set; }

        public List<int> LanguageIds { get; set; }

        public int Id { get; set; }

        public EditPersonViewModel()
        {

        }
    }
}
