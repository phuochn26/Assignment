using System.Collections.Generic;
using EF1.Models;

namespace EF1.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        List<Student> FilterStudent(string firstName, string lastName, string city, string state);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);

    }
}