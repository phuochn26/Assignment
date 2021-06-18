using System;

public class Member{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public int _age { get; set;}
    public int Age { get{
        return DateTime.Now.Year - DateOfBirth.Year;
    }
    set{
        this.Age = this._age;
    } }
    public bool IsGraduate { get; set; }
}