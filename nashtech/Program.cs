using System;
using System.Collections.Generic;
using System.Linq;

namespace nashtech
{
    class Program
    {
        static List<Member> members = new List<Member>(){
            new Member(){
            FirstName = "Phuoc",
            LastName = "Hoang Nhat",
            Gender = "Male",
            DateOfBirth = new DateTime(2000,11,25),
            PhoneNumber = "",
            BirthPlace = "Hai Phong",
            IsGraduate = false,
            },
            new Member(){
            FirstName = "Trang",
            LastName = "Nguyen Huyen",
            Gender = "Female",
            DateOfBirth = new DateTime(2002,1,1),
            PhoneNumber = "",
            BirthPlace = "Hai Duong",
            IsGraduate = false,
            },
            new Member(){
            FirstName = "Ky",
            LastName = "Nguyen Khac",
            Gender = "Male",
            DateOfBirth = new DateTime(1996,1,1),
            PhoneNumber = "",
            BirthPlace = "Bac Giang",
            IsGraduate = false,
            },
            new Member(){
            FirstName = "Dat",
            LastName = "Dam Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(1997,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Member(){
            FirstName = "Long",
            LastName = "Thang Bao",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            },
            new Member(){
            FirstName = "Van",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            }
            };
        static void PrintList(List<Member> list){
            foreach(var member in list){
                Console.WriteLine(member.LastName + " " + member.FirstName);
            }
        }
        static void Print(Member member){
            Console.WriteLine($"{member.LastName} {member.FirstName} ({member.Age})");
        }
        //1
        static void PrintAllMaleMember(List<Member> list){
            var results = list.Where(member => member.Gender.Equals("Male")).ToList();
            PrintList(results);
        }
        //2
        static void PrintOldestMember(List<Member> list){
            var max = list.Max(Member => Member.Age);
            var results = list.Where(member => member.Age == max).ToList();
            var result = results.FirstOrDefault();
            Console.Write("The oldest member is:");
            Print(result);
        }
        //3
        static void PrintFullName(List<Member> list){
            var results = list.Select(member =>{
                return member.FirstName + " " + member.LastName;
            }).ToList();
            foreach(var result in results){
                Console.WriteLine(result);
            }
        }
        //4
        static void SplitMemberByBirthYear(List<Member> list, int yearOfBirth){
            var lessThan = list.Where(member => member.DateOfBirth.Year < yearOfBirth).ToList();
            var equalTo = list.Where(member => member.DateOfBirth.Year == yearOfBirth).ToList();
            var moreThan = list.Where(member => member.DateOfBirth.Year > yearOfBirth).ToList();

            Console.WriteLine("Members that have birth year equal to " + yearOfBirth + ":");
            foreach(Member member in equalTo){
                Console.WriteLine(member.LastName + " " + member.FirstName);
            }
            Console.WriteLine("Members that have birth year more than " + yearOfBirth + ":");
            foreach(Member member in moreThan){
                Console.WriteLine(member.LastName + " " + member.FirstName + "(" + member.DateOfBirth.Year + ")");
            }
            Console.WriteLine("Members that have birth year less than " + yearOfBirth + ":");
            foreach(Member member in lessThan){
                Console.WriteLine(member.LastName + " " + member.FirstName + "(" + member.DateOfBirth.Year + ")");
            }
        }
        //5
        static void PrintTheFirstPersonByBirthPlace(List<Member> list, string place){
            var results = list.Where(m => m.BirthPlace.Equals(place , StringComparison.OrdinalIgnoreCase)).ToList();
            var result = results.FirstOrDefault();
            if (result != null)
            {
                Console.Write("The first person who born in " + place + " is:");
                Print(result);
            }
            else
            {
                Console.WriteLine("There is no one who born in " + place);
            }
        }
        static void Main(string[] args)
        {
            //PrintAllMaleMember(members);
            //PrintOldestMember(members);
            //PrintFullName(members);
            //SplitMemberByBirthYear(members, 2000);
            PrintTheFirstPersonByBirthPlace(members, "Ha Noi");
        }
    }
}
