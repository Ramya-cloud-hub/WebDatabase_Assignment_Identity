using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CitiesController : Controller
    {
        private readonly ICityService _service;
        private readonly ICountryService _countryService;

        public CitiesController(ICityService service, ICountryService countryService)
        {
            this._service = service;
            this._countryService = countryService;
        }
        public IActionResult CitiesIndex()
        {
            ViewBag.Countries = new SelectList(_countryService.All().Countries, "Id", "Name");

            return View(_service.All());
        }

        [HttpGet("cities/{id}")]
        public IActionResult GetCity(int id)
        {
            try
            {
                CityViewModel city = _service.FindBy(id);
                return PartialView("City", city);
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction("CitiesIndex");
            }
        }

        [HttpPost]
        public IActionResult CreateCity(CreateCityViewModel city)
        {
            if (ModelState.IsValid)
            {
                _service.Add(city);
            }

            return RedirectToAction("CitiesIndex");
        }
        
        [HttpPost]
        public IActionResult UpdateCity(EditCityViewModel city)
        {
            
            CityViewModel editedCity =_service.Edit(city);
        
            return PartialView("City", editedCity);
        }

        [HttpGet("cities/del/{id}")]
        public IActionResult DeleteCity(int id)
        {
            _service.Remove(id);
            return RedirectToAction("CitiesIndex");
        }
    }
}
