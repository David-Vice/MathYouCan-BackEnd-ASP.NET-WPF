using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return Ok(await _studentService.GetAll());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OfflineExam>> GetById(int id)
        {
            var exam = await _studentService.Get(id);
            if (exam == null)
            {
                return NotFound($"Student with id {id} was not found");
            }

            return Ok(exam);
        }
        [HttpPost]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Please enter values of student");
            }
            
            await _studentService.Add(student);
            return Ok(student.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var itemToDelete = await _studentService.Get(id);
            if (itemToDelete == null)
            {
                return NotFound($"Student with id {id} was not found");
            }
            await _studentService.Delete(itemToDelete);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Update(int id, Student student)
        {
            try
            {
                var itemToUpdate = await _studentService.Get(id);
                if (itemToUpdate == null)
                    return NotFound($"Student with id {id} was not found");

                return await _studentService.Update(itemToUpdate, student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
