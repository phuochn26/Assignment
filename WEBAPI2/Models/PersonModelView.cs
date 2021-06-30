using System;
namespace WEBAPI2.Models
{
    public class PersonModelView
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}