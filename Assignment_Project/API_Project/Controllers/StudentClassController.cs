using API_Project.DataTransferObjects;
using API_Project.Domain.Models;
using API_Project.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {

        private IStudentGradeRepository _studentGradeRepository;
        private IMapper _mapper;
        public StudentClassController(IStudentGradeRepository studentGradeRepository
            ,IMapper mapper)
        {
            _studentGradeRepository = studentGradeRepository;
            _mapper = mapper;
        }
        // GET: api/<StudentClassController>
        [HttpGet]
        public IEnumerable<StudentClass> Get()
        {
            var studentClasses = _studentGradeRepository.GetAll();
            return studentClasses;
        }

        // GET api/<StudentClassController>/5
        [HttpGet("{id}")]
        public StudentClassDTO Get(int id)
        {
            var studentClass = _studentGradeRepository.GetById(id);

            if (studentClass == null)
            {
                return null;
            }
            StudentClassDTO dto = new StudentClassDTO();
            dto.Id = studentClass.Id;
            dto.className = studentClass.Class;
            return dto;
        }

        // POST api/<StudentClassController>
        [HttpPost]
        public void Post([FromBody] StudentClassDTO value)
        {
            StudentClass studentClass = new StudentClass();
            studentClass.Class = value.className;
            
            _studentGradeRepository.Add(studentClass);
        }

        // PUT api/<StudentClassController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentClassDTO value)
        {
            var existingClass = _studentGradeRepository.GetById(id);

            if (existingClass == null)
            {
                return NotFound();
            }

            // Update properties as needed
            _studentGradeRepository.Update(id, value.className);
            return Ok();
        }

        // DELETE api/<StudentClassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingClass = _studentGradeRepository.GetById(id);

            if (existingClass == null)
            {
                
            }

            _studentGradeRepository.Delete(id);
        }
    }
}
