using System.Collections.Generic;
using System.Linq;
using EF1.Models;

namespace EF1.Services.Implemention
{
    public class StudentService : IStudentService
    {
        private StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public List<Student> GetStudents()
        {
            return _studentContext.Students.ToList();
        }
        public Student GetStudentById(int id)
        {
            return _studentContext.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }
        public void CreateStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var st = _studentContext.Students.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
            st.FirstName = student.FirstName;
            st.LastName = student.LastName;
            st.City = student.City;
            st.State = student.State;
            _studentContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var st = _studentContext.Students.Where(s => s.StudentId == id).FirstOrDefault();
            _studentContext.Students.Remove(st);
            _studentContext.SaveChanges();
        }

        public List<Student> FilterStudent(string firstName, string lastName, string city, string state)
        {
            return _studentContext.Students.Where(x => (!string.IsNullOrEmpty(firstName) && x.FirstName.ToLower().Contains(firstName.ToLower())) ||
                                      (!string.IsNullOrEmpty(lastName) && x.LastName.ToLower().Contains(lastName.ToLower())) ||
                                      (!string.IsNullOrEmpty(city) && x.City.ToLower().Contains(city.ToLower())) ||
                                      (!string.IsNullOrEmpty(state) && x.FirstName.ToLower().Contains(state.ToLower()))).ToList();
        }
    }
}