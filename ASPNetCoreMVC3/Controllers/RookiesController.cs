using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNetCoreMVC3.Models;
using System.Text.Json;
using ASPNetCoreMVC3.Service;
using Microsoft.AspNetCore.Http;

namespace ASPNetCoreMVC3.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private readonly IPersonService _personService;
        public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        public IActionResult Index()
        {
            var data = _personService.GetAll();
            return View(data);
        }
        public IActionResult Detail(int id)
        {
            var data = _personService.GetOne(id);
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if(!ModelState.IsValid){
                ViewBag.Error = JsonSerializer.Serialize(person);
                return View();
            }
            
            _personService.Create(person);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id){
            var data = _personService.GetOne(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Person person){
            if (!ModelState.IsValid){
                ViewBag.Error = JsonSerializer.Serialize(person);
                return View();
            }
            _personService.Edit(person);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id){
            _personService.GetOne(id);
            HttpContext.Session.SetString("DELETED_PERSON", _personService.GetOne(id).LastName + " " + _personService.GetOne(id).FirstName);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Person person){
            _personService.Delete(person);
            return RedirectToAction("DeleteMessage");
        }
        public IActionResult DeleteMessage(int id){
            return View();
        }
    }

}
