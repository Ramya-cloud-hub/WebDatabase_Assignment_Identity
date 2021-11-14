using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAppAssignmentDATABASE_5.Data.Exceptions;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    [AllowAnonymous]
    public class ReactController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountryService _countryService;

        public ReactController(IPeopleService peopleService, ICountryService countryService)
        {
            this._peopleService = peopleService;
            this._countryService = countryService;
        }

        [HttpGet("[controller]")]
        public IActionResult GetMainPage()
        {
            return File("/react/build/index.html", "text/html");
        }

        [HttpGet("[controller]/people")]
        public ActionResult<PeopleViewModel> GetAllPeople()
        {
            return new OkObjectResult(_peopleService.All());
        }

        [HttpGet("[controller]/countries")]
        public ActionResult<CountriesViewModel> GetAllCountries()
        {
            return new OkObjectResult(_countryService.All());
        }

        [HttpGet("[controller]/people/{id}")]
        public ActionResult<PeopleViewModel> GetOne(int id)
        {
            try
            {
                return new OkObjectResult(_peopleService.FindBy(id));
            }catch(EntityNotFoundException)
            {
                return new NotFoundResult();
            }

        }

        [HttpPost("[controller]/people")]
        public ActionResult<PersonViewModel> AddPerson([FromBody]CreatePersonViewModel person)
        {

            if (ModelState.IsValid)
            {
                PersonViewModel createdPerson = _peopleService.Add(person);
                
                return new OkObjectResult(createdPerson);
            }

            return new BadRequestResult();

        }

        [HttpDelete("[controller]/people/{id}")]
        public IActionResult RemovePerson(int id)
        {
            if (_peopleService.Remove(id))
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}
