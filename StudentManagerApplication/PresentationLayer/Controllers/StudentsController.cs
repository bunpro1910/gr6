using BusinessServiceLayer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Group6Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        StudentService studentService;
        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet]
        public List<StudentDTO> Get()
        {
            return studentService.Get();
        }

        [HttpGet]
        [Route("Filter")]
        public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        {
            return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public StudentDTO Get(int id)
        {
            return studentService.Get(id);
            
        }
       

        [HttpPost]
        public ActionResult Post( StudentDTO student)
        {
            if(ModelState.IsValid)
            {
                studentService.Post(student);
                return NoContent();
            }
            return BadRequest();

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentDTO student)
        {
            if(id!= student.StudentId)
            {
                return BadRequest();
            }

            if (studentService.Put(id, student))
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (studentService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
