using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI2.Models;
using WEBAPI2.Services;

namespace WEBAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public List<PersonModelView> Get()
        {
            return _personService.GetPersons();
        }
        [HttpPost]
        public PersonModelView Create(PersonModelView person)
        {
            _personService.CreatePerson(person);
            return person;
        }
        [HttpPut("id")]
        public IActionResult Update(int id,PersonModelView person)
        {
            var checkId = _personService.GetPersonById(id);
            if (checkId != null)
            {
                _personService.UpdatePerson(person);
                return StatusCode(200);
            }
            return StatusCode(404);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var checkId = _personService.GetPersonById(id);
            if (checkId != null)
            {
                _personService.DeletePerson(id);
                return StatusCode(200);
            }
            return StatusCode(404);
        }
        [HttpGet("firstName")]
        public List<PersonModelView> FilterByFirstName(string firstName)
        {
            var check = _personService.FilterByFirstName(firstName);
            if(check != null)
            {
                return check;
            }
            return null;
        }
        [HttpGet("LastName")]
        public List<PersonModelView> FilterByLastName(string lastName)
        {
            var check = _personService.FilterByLastName(lastName);
            if(check != null)
            {
                return check;
            }
            return null;
        }
        [HttpGet("gender")]
        public List<PersonModelView> FilterByGender(string gender)
        {
            var check = _personService.FilterByGender(gender);
            if(check != null)
            {
                return check;
            }
            return null;
        }
        [HttpGet("birthPlace")]
        public List<PersonModelView> FilterByBirthPlace(string birthPlace)
        {
            var check = _personService.FilterByBirthPlace(birthPlace);
            if(check != null)
            {
                return check;
            }
            return null;
        }
    }
}
