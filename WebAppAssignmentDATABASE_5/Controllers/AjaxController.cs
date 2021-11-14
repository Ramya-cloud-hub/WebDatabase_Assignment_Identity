using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data.Exceptions;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class AjaxController : Controller
    {
        private IPeopleService _service;

        public AjaxController(IPeopleService service)
        {
            _service = service;
        }

        public IActionResult AjaxPeople()
        {
            return View();
        }

        public IActionResult LoadPeople()
        {
            return PartialView("PeopleList", _service.All());
        }

        [HttpPost]
        public IActionResult Details(int id)
        {
            try
            {
                PersonViewModel person = _service.FindBy(id);
                return PartialView("PeopleList", new PeopleViewModel() { People = new List<PersonViewModel>() { person } });
            }
            catch (EntityNotFoundException)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if(_service.Remove(id))
                return new StatusCodeResult((int)HttpStatusCode.NoContent);

            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }
    }
}
