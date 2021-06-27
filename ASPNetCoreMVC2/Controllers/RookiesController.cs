using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNetCoreMVC2.Models;
using System.Text.Json;

namespace ASPNetCoreMVC2.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        static List<Person> persons = new List<Person>()
        {
            new Person(){
            Id = 1,
            FirstName = "Phuoc",
            LastName = "Hoang Nhat",
            Gender = "Male",
            DateOfBirth = new DateTime(2000,11,25),
            PhoneNumber = "",
            Email = "phuochn26@gmail.com",
            BirthPlace = "Hai Phong",
            IsGraduate = false,
            },
            new Person(){
            Id = 2,
            FirstName = "Trang",
            LastName = "Nguyen Huyen",
            Gender = "Female",
            DateOfBirth = new DateTime(2002,11,12),
            PhoneNumber = "",
            Email = "Trangnguyenhuyen@gmail.com",
            BirthPlace = "Hai Duong",
            IsGraduate = false,
            },
            new Person(){
            Id = 3,
            FirstName = "Ky",
            LastName = "Nguyen Khac",
            Gender = "Male",
            DateOfBirth = new DateTime(1996,1,1),
            PhoneNumber = "",
            Email = "KyNguyen@gmail.com",
            BirthPlace = "Bac Giang",
            IsGraduate = false,
            },
            new Person(){
            Id = 7,
            FirstName = "Dat",
            LastName = "Dam Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(1997,7,14),
            PhoneNumber = "",
            Email = "Datdamtuan@gmail.com",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Person(){
            Id = 5,
            FirstName = "Long",
            LastName = "Thang Bao",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,16),
            PhoneNumber = "",
            Email = "ThangBaoLe@gmail.com",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Person(){
            Id = 10,
            FirstName = "Van",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,4,5),
            PhoneNumber = "",
            Email = "NguyenCongVan@gmail.com",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            }
        };

        public IActionResult Index()
        {
            return View(persons);
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

            persons.Add(person);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id){
            var person = persons.FirstOrDefault(m => m.Id == id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person){
            if (!ModelState.IsValid){
                ViewBag.Error = JsonSerializer.Serialize(person);
                return View();
            }

            var st = persons.Find( p => p.Id ==person.Id );
            persons.Remove(st);
            persons.Add(person);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id){
            var person = persons.FirstOrDefault(m => m.Id == id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Delete(Person person){
            var st = persons.Find( p => p.Id ==person.Id );
            persons.Remove(st);
            return RedirectToAction("Index", persons);
        }
    }
}
