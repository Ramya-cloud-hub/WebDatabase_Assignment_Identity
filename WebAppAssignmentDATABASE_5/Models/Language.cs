using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class Language
    {
        private int id;
        [Key]
        public int Id { get { return id; } set { id = value; } }

        private string name;
        [Required]
        [MaxLength(50)]
        public string Name { get { return name; } set { name = value; } }

        private List<LanguagePerson> people;
        public List<LanguagePerson> People { get { return people; } set { people = value; } }

        public Language()
        {

        }
    }
}
