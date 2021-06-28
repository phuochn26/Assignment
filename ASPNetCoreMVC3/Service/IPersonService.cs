using System;
using System.Collections.Generic;
using ASPNetCoreMVC3.Models;

namespace ASPNetCoreMVC3.Service
{
    public interface IPersonService
    {
        List<Person> GetAll();   
        Person GetOne(int id);   
        void Create(Person person);
        void Edit(Person person);
        void Delete(Person person);
    }
}