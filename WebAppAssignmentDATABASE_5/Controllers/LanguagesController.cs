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
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _service;

        public LanguagesController(ILanguageService service)
        {
            this._service = service;
        }
        public IActionResult LanguageIndex()
        {
            return View(_service.All());
        }

        public IActionResult CreateLanguage(CreateLanguageViewModel language)
        {
            _service.Add(language);
            return RedirectToAction("LanguageIndex");
        }

        public IActionResult RemoveLanguage(int id)
        {
            _service.Remove(id);
            return RedirectToAction("LanguageIndex");

        }

        public IActionResult FindLanguage(int id)
        {
            try
            {
                return PartialView("Language", _service.FindBy(id));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction("LanguageIndex");
            }
        }
    }
}
