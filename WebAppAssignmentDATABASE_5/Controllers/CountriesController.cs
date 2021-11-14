using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data.Exceptions;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService service)
        {
            this._service = service;
        }
        public IActionResult CountriesIndex()
        {
            return View(_service.All());
        }

        [HttpGet("/countries/{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                CountryViewModel country =_service.FindBy(id);
                return PartialView("Country", country);
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction("CountriesIndex");
            }
        }

        [HttpPost]
        public IActionResult CreateCountry(CreateCountryViewModel country)
        {
            _service.Add(country);
            return RedirectToAction("CountriesIndex");
        }

        [HttpGet("/countries/del/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _service.Remove(id);
            return RedirectToAction("CountriesIndex");
        }

        [HttpPost]
        public IActionResult UpdateCountry(EditCountryViewModel country)
        {

            CountryViewModel editedCountry = _service.Edit(country);

            return PartialView("Country", editedCountry);
        }
    }
}
