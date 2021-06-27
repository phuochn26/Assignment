using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMVC2.Models
{
     public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [RegularExpression("^\\d{9,}$", ErrorMessage = "Phone number is not Valid")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.+[a-zA-Z]{2,6})$",ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        public string BirthPlace { get; set; }
        public int Age 
        {
            get
            {
            return DateTime.Now.Year - DateOfBirth.Year;
            }
            set
            {
            this.Age = value;
            } 
        }
        public bool IsGraduate { get; set; }
    }
}