using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCoreMVC3.Models;

namespace ASPNetCoreMVC3.Service
{
    public class PersonService : IPersonService
    {
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

        List<Person> IPersonService.GetAll()
        {
            return persons;
        }

        Person IPersonService.GetOne(int id)
        {
            var person = persons.FirstOrDefault(m => m.Id == id);
            return person;
        }
        void IPersonService.Create(Person person)
        {
            persons.Add(person);
        }

        void IPersonService.Edit(Person person)
        {
            var st = persons.Find( p => p.Id ==person.Id );
            persons.Remove(st);
            persons.Add(person);
        }

        void IPersonService.Delete(Person person)
        {
            var st = persons.Find( p => p.Id ==person.Id );
            persons.Remove(st);        
        }
    }
}