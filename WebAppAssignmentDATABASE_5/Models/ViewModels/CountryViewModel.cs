using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        public string Name { get; set; }

        public int Id { get; set; }

        public List<CityViewModel> Cities { get; set; }

        public CountryViewModel()
        {

        }
    }
}
