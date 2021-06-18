using System;
using System.Collections.Generic;

namespace nashtech
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();
            members.Add(new Member(){
            FirstName = "Phuoc",
            LastName = "Hoang Nhat",
            Gender = "Male",
            DateOfBirth = new DateTime(2000,11,25),
            PhoneNumber = "",
            BirthPlace = "Hai Phong",
            IsGraduate = false,
            });
            members.Add(new Member(){
            FirstName = "Trang",
            LastName = "Nguyen Huyen",
            Gender = "Female",
            DateOfBirth = new DateTime(2002,1,1),
            PhoneNumber = "",
            BirthPlace = "Hai Duong",
            IsGraduate = false,
            });
            members.Add(new Member(){
            FirstName = "Ky",
            LastName = "Nguyen Khac",
            Gender = "Male",
            DateOfBirth = new DateTime(1996,1,1),
            PhoneNumber = "",
            BirthPlace = "Bac Giang",
            IsGraduate = false,
            });
            members.Add(new Member(){
            FirstName = "Dat",
            LastName = "Dam Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(1997,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            });
            members.Add(new Member(){
            FirstName = "Long",
            LastName = "Thang Bao",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            });
            members.Add(new Member(){
            FirstName = "Van",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(1999,1,1),
            PhoneNumber = "",
            BirthPlace = "Ha Noi",
            IsGraduate = false,
            });
        
            //1
            Console.WriteLine("1");
            Console.WriteLine("All male member are:");
            foreach(Member member in members){
                if(member.Gender == "Male"){
                    Console.WriteLine(member.LastName + " " + member.FirstName);
                }
            }
        
            //2
            Console.WriteLine("2");
            Member oldestMember = members[0];

            foreach(Member member in members){
                if(oldestMember.Age < member.Age){
                    oldestMember = member;
                }
            }

            Console.WriteLine("The Oldest member is " + oldestMember.LastName + " " + oldestMember.FirstName + "(" + oldestMember.Age + ")" );
        
            //3
            Console.WriteLine("3");
            List<string> fullNameList = new List<string>();

            foreach(Member member in members){
                fullNameList.Add(new string (member.LastName + " " + member.FirstName));
            }

            foreach (string fullName in fullNameList){
                Console.WriteLine(fullName);
            }

            //4
            Console.WriteLine("4");

            List<Member> mem2k = new List<Member>();
            List<Member> memLessThan2k = new List<Member>();
            List<Member> memMoreThan2k = new List<Member>();
            foreach(Member member in members){
                switch(member.DateOfBirth.Year){
                    case int a when a == 2000:
                        mem2k.Add(member);
                        break;
                    case int a when a < 2000:
                        memLessThan2k.Add(member);
                        break;
                    case int a when a > 2000:
                        memMoreThan2k.Add(member);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Members that have birth year equal to 2000:");
            foreach(Member member in mem2k){
                Console.WriteLine(member.LastName + " " + member.FirstName);
            }
            Console.WriteLine("Members that have birth year more than 2000:");
            foreach(Member member in memMoreThan2k){
                Console.WriteLine(member.LastName + " " + member.FirstName + "(" + member.DateOfBirth.Year + ")");
            }
            Console.WriteLine("Members that have birth year less than 2000:");
            foreach(Member member in memLessThan2k){
                Console.WriteLine(member.LastName + " " + member.FirstName + "(" + member.DateOfBirth.Year + ")");
            }

            //5
            Console.WriteLine("5");
            int tmp = 0;
            while(tmp < members.Count){
                if(members[tmp].BirthPlace == "Ha Noi"){
                    Console.WriteLine(members[tmp].FirstName + " " + members[tmp].LastName + " was born in Ha Noi");
                    tmp = members.Count;
                }
                tmp++;
            }
        }
    }
}
