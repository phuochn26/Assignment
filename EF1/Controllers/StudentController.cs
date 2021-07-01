using System.Collections.Generic;
using EF1.Models;
using EF1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public List<Student> List()
        {
            return _studentService.GetStudents();
        }
        [HttpPost]
        public Student Create(Student student)
        {
            _studentService.CreateStudent(student);
            return student;
        }
        [HttpPut("id")]
        public IActionResult Update(int id,Student student)
        {
            if(id == 0)
            {
                return StatusCode(404);
            }
            else
            {
                _studentService.UpdateStudent(student);
            }
            return StatusCode(200);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if(_studentService.GetStudentById(id) == null)
            {
                return StatusCode(404);
            }
            else
            {
                _studentService.DeleteStudent(id);
            }
            return StatusCode(200);
        }
        [HttpGet("Student")]
        public List<Student> FilterStudent(string firstName, string lastName, string city, string state)
        {
            List<Student> filter = _studentService.FilterStudent(firstName, lastName, city, state);
            if(filter != null)
            {
                return filter;
            }
            return null;
        }
    }
}
