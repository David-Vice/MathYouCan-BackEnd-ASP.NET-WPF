using ActAPI.Handlers;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public QuestionController(IQuestionService questionService,IWebHostEnvironment webHostEnvironment)
        {
            _questionService = questionService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetById(int id)
        {
            var question = await _questionService.Get(id);
            if (question == null) return NotFound($"Question with id: {id} was not found");
            return Ok(question);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            return Ok(await _questionService.GetAll());
        }

        [HttpPost]
        //public async Task<ActionResult> AddQuestion([ModelBinder(BinderType = typeof(JsonModelBinder))]Question question, IFormFile? formFile)
        public async Task<ActionResult> AddQuestion(Question question)
        {
            try
            {
                if (question == null) return BadRequest("Question was not provided");
                if (question.SectionId == null)
                    return BadRequest("Could not connect question to section, because section id was not provided");
                await _questionService.Add(question);
                //if (formFile != null)
                //{
                //    question.PhotoName = await FileHandler.UploadFile(question.Section.OfflineExamId, formFile, question.Id, 'q');
                //    await _questionService.Update(question, question);
                //}
                return Ok(question.Id);
            }
            catch (NullReferenceException)
            {
                return NotFound("Section with provided id does not exist or refences to null");
            }
        }

        [HttpPut("{id}/UploadImage")]
        public async Task<ActionResult> UploadImage(int id, IFormFile formFile)
        {
            try
            {
                if (formFile == null) return BadRequest("To file provided");

                Question? question = _questionService.Get(id).Result;
                if (question == null) return NotFound($"No quetion with id: {id} exist!");

                question.PhotoName = await FileHandler.UploadFile(_webHostEnvironment,question.Section?.OfflineExamId, formFile, id, 'q');
                await _questionService.Update(question, question);

                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var questionToDelete = await _questionService.Get(id);
            if (questionToDelete == null) return NotFound($"Question with id: {id} was not found");

            await _questionService.Delete(questionToDelete);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Question>> UpdateQuestion(int id, Question newQuestion)
        {
            try
            {
                var questionToUpdate = await _questionService.Get(id);
                if (questionToUpdate == null) return NotFound($"Question with id: {id} was not found");
                return await _questionService.Update(questionToUpdate, newQuestion);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
