using System;
using System.Collections.Generic;
using WEBAPI2.Models;

namespace WEBAPI2.Services
{
    public interface IPersonService
    {
        List<PersonModelView> GetPersons();
        PersonModelView GetPersonById(int id);
        List<PersonModelView> FilterByFirstName(string firstName);
        List<PersonModelView> FilterByLastName(string lastName);
        List<PersonModelView> FilterByGender(string gender);
        List<PersonModelView> FilterByBirthPlace(string birthPlace);
        void CreatePerson(PersonModelView person);
        void UpdatePerson(PersonModelView person);
        void DeletePerson(int id);

    }
}