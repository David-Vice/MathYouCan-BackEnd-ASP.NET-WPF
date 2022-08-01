using ActAPI.Models;
using ActAPI.Models.Dto;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OfflineExamController : ControllerBase
    {
        private readonly IOfflineExamService _offlineExamService;
        public OfflineExamController(IOfflineExamService offlineExamService)
        {
            _offlineExamService= offlineExamService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfflineExam>>> GetAll()
        {
            return Ok(await _offlineExamService.GetAll());
        }
        [HttpGet]
        [Route("ExamDetails")]
        public ActionResult<IEnumerable<OfflineExamDetails>> GetAllExamDetails()
        {
            return Ok(_offlineExamService.GetAllExamDetails());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OfflineExam>> GetById(int id)
        {
            var exam = await _offlineExamService.Get(id);
            if (exam == null)
            {
                return NotFound($"Exam with id {id} was not found");
            }

            return Ok(exam);
        }
        [HttpPost]
        public async Task<ActionResult> CreateExam(OfflineExam offlineExam)
        {
            if (offlineExam==null)
            {
                return BadRequest("Please enter name of Exam");
            }
            var details=_offlineExamService.GetAllExamDetails();
            foreach (var item in details)
            {
                if (offlineExam.Name==item.Name)
                {
                    return BadRequest("Exam with this name has already been created");
                }
            }
            await _offlineExamService.Add(offlineExam);
            return Ok(offlineExam.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExam(int id)
        {
            var itemToDelete = await _offlineExamService.Get(id);
            if (itemToDelete == null)
            {
                return NotFound($"Exam with id {id} was not found");
            }
            await _offlineExamService.Delete(itemToDelete);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OfflineExam>> UpdateExam(int id, OfflineExam offlineExam)
        {
            try
            {
                var itemToUpdate = await _offlineExamService.Get(id);
                if (itemToUpdate == null)
                    return NotFound($"Exam with id {id} was not found");

                return await _offlineExamService.Update(itemToUpdate, offlineExam);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
