using System;
using System.Collections.Generic;
using System.Linq;
using WEBAPI2.Models;

namespace WEBAPI2.Services.Implemention
{
    public class PersonService : IPersonService
    {
        static List<PersonModelView> persons = new List<PersonModelView>()
        {
            new PersonModelView(){
            Id = 1,
            FirstName = "Phuoc",
            LastName = "Hoang Nhat",
            Gender = "Male",
            DateOfBirth = new DateTime(2000,11,25),
            BirthPlace = "Hai Phong",
            },
            new PersonModelView(){
            Id = 2,
            FirstName = "Trang",
            LastName = "Nguyen Huyen",
            Gender = "Female",
            DateOfBirth = new DateTime(2002,11,12),
            BirthPlace = "Hai Duong",
            },
            new PersonModelView(){
            Id = 3,
            FirstName = "Ky",
            LastName = "Nguyen Khac",
            Gender = "Male",
            DateOfBirth = new DateTime(1996,1,1),
            BirthPlace = "Bac Giang",
            },
            new PersonModelView(){
            Id = 5,
            FirstName = "Dat",
            LastName = "Dam Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(1997,7,14),
            BirthPlace = "Ha Noi",
            },
            new PersonModelView(){
            Id = 10,
            FirstName = "Long",
            LastName = "Thang Bao",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,16),
            BirthPlace = "Ha Noi",
            },
            new PersonModelView(){
            Id = 20,
            FirstName = "Van",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,4,5),
            BirthPlace = "Ha Noi",
            }
        };

        public List<PersonModelView> GetPersons()
        {
            return persons;
        }
        

        public PersonModelView GetPersonById(int id)
        {
            return persons.Find(p => p.Id == id);
        }
        public List<PersonModelView> FilterByFirstName(string firstName)
        {
            return persons.Where(x => (!string.IsNullOrEmpty(firstName) && x.FirstName.ToLower().Contains(firstName.ToLower()))).ToList();
        }
        public List<PersonModelView> FilterByLastName(string lastName)
        {
            return persons.Where(x => (!string.IsNullOrEmpty(lastName) && x.LastName.ToLower().Contains(lastName.ToLower()))).ToList();
        }
        public List<PersonModelView> FilterByGender(string gender)
        {
            return persons.Where(x => (!string.IsNullOrEmpty(gender) && x.Gender.ToLower() == gender.ToLower())).ToList();
        }
        public List<PersonModelView> FilterByBirthPlace(string birthPlace)
        {
            return persons.Where(x => (!string.IsNullOrEmpty(birthPlace) && x.BirthPlace.ToLower().Contains(birthPlace.ToLower()))).ToList();
        }
        public void CreatePerson(PersonModelView person)
        {
            persons.Add(person);
        }

        public void UpdatePerson(PersonModelView person)
        {
            var st = persons.FindIndex(p => p.Id == person.Id);
            persons[st] = person;
        }

        public void DeletePerson(int id)
        {
            persons.Remove(persons.Find(p => p.Id == id));
        }
    }
}