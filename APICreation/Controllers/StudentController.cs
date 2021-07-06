using APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICreation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class StudentController : Controller
    {
        

        // This is a workaround, but since data does not persist in controllers,

        // We'll create a method that serves up our list of students
        public List<Student> PopulateList()
        {
            List<Student> Students = new List<Student>();
            Students.Add(new Student() { Id = 0, Age = 20, Name = "George" });
            Students.Add(new Student() { Id = 2, Age = 32, Name = "Jorge" });
            Students.Add(new Student() { Id = 3, Age = 38, Name = "Manal" });
            Students.Add(new Student() { Id = 8, Age = 62, Name = "Fatima" });
            return Students;
        }

        [HttpGet]
        // Leave off the route tag so this shows up at Student/
        // It is the default method
        public List<Student> GetStudents()
        {
            List<Student> students = PopulateList();
            return students;
        }

        [HttpGet]
        [Route("Search/{str}")]
        public Student SearchStudent (string str)
        {
            List<Student> students = PopulateList();
            Student output = students.Where(x => x.Name == str).First();
            return output;
            
        }

        [HttpGet]
        [Route("Search/Age={age}")]
        public List<Student> SearchByYoungerThan(int age)
        {
            List<Student> students = PopulateList();
            List<Student> output = students.Where(x => x.Age < age).ToList();
            return output;
        }
    }
}
