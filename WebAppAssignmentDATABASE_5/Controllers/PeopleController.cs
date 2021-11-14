using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    
    public class PeopleController : Controller
    {
        private static IPeopleService _peopleService;
        private static ICityService _cityService;
        private static ILanguageService _languageService { get; set; }

        public PeopleController(IPeopleService peopleService, ICityService cityService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _languageService = languageService;
        }
        [Authorize(Roles = "User, Admin")]
        public IActionResult PeopleIndex()
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "Id", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "Id", "LanguageName");

         return View(_peopleService.All());
        }
        
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public IActionResult AddPerson(CreatePersonViewModel person) 
        {

            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
            }

            return RedirectToAction("PeopleIndex");
        }
        [Authorize(Roles = "User, Admin")]
        public IActionResult FilterPeople(PeopleViewModel searchTerms)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "Id", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "Id", "LanguageName");

            return View("PeopleIndex", _peopleService.FindBy(searchTerms)); 
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RemovePerson(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction("PeopleIndex");
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public IActionResult SortPeople(SortingModel sortingModel)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "Id", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "Id", "LanguageName");

            return View("PeopleIndex", _peopleService.SortBy(sortingModel.FieldName, sortingModel.Alphabetical));
        }

        [HttpPost("people/UpdatePerson")]
        [Authorize(Roles = "User, Admin")]
        public IActionResult UpdatePerson(EditPersonViewModel person)
        {
            PersonViewModel editedPerson = _peopleService.Edit(person.Id, person);

            return PartialView("PersonView", editedPerson);
        }

    }
}
