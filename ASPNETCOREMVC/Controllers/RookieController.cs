using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNETcoreMVC.Models;
using System.Text.Json;
using System.IO;
using System.Text;
using Microsoft.Net.Http.Headers;
using System.Globalization;
using CsvHelper;

namespace ASPNETcoreMVC.Controllers
{
    public class RookieController : Controller
    {
        private readonly ILogger<RookieController> _logger;
        public RookieController(ILogger<RookieController> logger)
            {
                _logger = logger;
            }

        static List<Person> persons = new List<Person>(){
            new Person(){
            FirstName = "Phuoc",
            LastName = "Hoang Nhat",
            Gender = "Male",
            DateOfBirth = new DateTime(2000,11,25),
            PhoneNumber = "",
            BirthPlace = "Hai Phong",
            IsGraduate = false,
            },
            new Person(){
            FirstName = "Trang",
            LastName = "Nguyen Huyen",
            Gender = "Female",
            DateOfBirth = new DateTime(2002,1,1),
            PhoneNumber = "",
            BirthPlace = "Hai Duong",
            IsGraduate = false,
            },
            new Person(){
            FirstName = "Ky",
            LastName = "Nguyen Khac",
            Gender = "Male",
            DateOfBirth = new DateTime(1996,1,1),
            PhoneNumber = "",
            BirthPlace = "Bac Giang",
            IsGraduate = false,
            },
            new Person(){
            FirstName = "Dat",
            LastName = "Dam Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(1997,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Person(){
            FirstName = "Long",
            LastName = "Thang Bao",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Person(){
            FirstName = "Van",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            }
        };

        public IActionResult Index(){
            return Json(persons);
        }
        //1
        public IActionResult GetMale(){
            var results = persons.Where(person => person.Gender.Equals("Male")).ToList();
            return Json(results);
        }
        //2
        public IActionResult GetOldestPerson(){
            var max = persons.Max(person => person.Age);
            var results = persons.Where(person => person.Age == max).ToList();
            var result = results.FirstOrDefault();
            return Json(result);
            }
        //3
        public IActionResult GetFullName(){
            var results = persons.Select(person =>{
               return $"{person.FirstName} {person.LastName}";
            }).ToList();
            return Json(results);
        }
        //4

        public IActionResult GetEqual(int yearOfBirth){
            var equalTo = persons.Where(person => person.DateOfBirth.Year == yearOfBirth).ToList();

            return Json(equalTo);
        }
        public IActionResult GetMore(int yearOfBirth){
            var moreThan = persons.Where(person => person.DateOfBirth.Year > yearOfBirth).ToList();

            return Json(moreThan);
        }
        public IActionResult GetLess(int yearOfBirth){
            var lessThan = persons.Where(person => person.DateOfBirth.Year < yearOfBirth).ToList();

            return Json(lessThan);
        }

        public IActionResult FilterPerson(int yearOfBirth, string type){
            switch(type){
                case "equal":
                    return GetEqual(yearOfBirth);
                    // return RedirectToAction("GetListPersonEqual", new { yearOfBirth });
                case "lessThan":
                    return GetLess(yearOfBirth);
                    // return RedirectToAction("GetLess", new { yearOfBirth });
                case "moreThan":
                    return GetMore(yearOfBirth);
                    // return RedirectToAction("GetMore", new { yearOfBirth });
                default:
                    return new EmptyResult();
            }
        }
        //5
        public IActionResult GetFullNameToExcel(){
            var results = persons.Select(person =>{
               return $"{person.FirstName} {person.LastName}";
            }).ToList();
            return Json(results);
        }
        //6
        public IActionResult Export(){
            var data = JsonSerializer.Serialize(persons);
            // var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            // return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain")){
            //     FileDownloadName = "data.txt"
            // };
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true);

            using(var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture)){
                csvWriter.WriteRecords(persons);
            }
            stream.Position = 0;
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/csv")){
                FileDownloadName = "data.csv"
            };
        }
    }
}