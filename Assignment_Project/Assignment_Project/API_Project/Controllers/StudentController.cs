using API_Project.DataTransferObjects;
using API_Project.Domain.Models;
using API_Project.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace API_Project.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        private IMapper _mapper;
        public StudentController(IStudentRepository studentRepository
            ,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;

        }
        [HttpPost]
        public IActionResult InsertPerson([FromBody] StudentDTO person)
        {
            Student student = new Student();
            student.Name= person.Name;
            student.StudentClassId = person.StudentClassId;
            student.Address = new Address();
            student.Address.City = person.Address.City;
            student.Address.AddressId = person.Address.AddressId;


             _studentRepository.Add(student);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Student> GetAllPeople()
        {
             IEnumerable<Student> students = _studentRepository.GetAllStudent();
            return students;
        }

        [HttpGet("{id}")]
        public StudentDTO GetPersonById(int id)
        {

            var person = _studentRepository.GetStudentById(id);

            
           StudentDTO student = new StudentDTO();
            student.Id = person.Id;
            student.Name = person.Name;
            student.StudentClassId = person.StudentClassId;
            student.Address = new AddressDTO();
            student.Address.City = person.Address.City;
            student.Address.AddressId = person.Address.AddressId;

            return student;
        }



        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDTO student2)
        {

            Student student = new Student();
            student.Id=student2.Id; 
            student.Name = student2.Name;
            student.StudentClassId = student2.StudentClassId;
            student.Address = new Address();
            student.Address.City = student2.Address.City;
            student.Address.AddressId = student2.Address.AddressId;


            // Update properties as needed
            _studentRepository.UpdateStudent(student);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            return Ok();
        }



    }
}
