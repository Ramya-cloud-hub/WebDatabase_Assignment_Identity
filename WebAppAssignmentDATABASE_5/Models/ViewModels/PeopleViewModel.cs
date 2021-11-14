using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class PeopleViewModel
    {
        [Required]
        public List<PersonViewModel> People { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string SearchTerm { get; set; }

        public bool CaseSensitive { get; set; }

        public PeopleViewModel()
        {

        }
    }
}
