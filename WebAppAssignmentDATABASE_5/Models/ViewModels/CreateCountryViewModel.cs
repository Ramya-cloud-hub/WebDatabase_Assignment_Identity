using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public CreateCountryViewModel()
        {

        }
    }
}
