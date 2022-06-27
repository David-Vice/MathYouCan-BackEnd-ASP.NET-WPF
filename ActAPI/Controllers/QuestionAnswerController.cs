using ActAPI.Handlers;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public QuestionAnswerController(IQuestionAnswerService questionAnswerService, IWebHostEnvironment webHostEnvironment)
        {
            _questionAnswerService = questionAnswerService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionAnswer>> GetById(int id)
        {
            var questionAnswer = await _questionAnswerService.Get(id);
            if (questionAnswer == null) return NotFound($"QuestionAnswer with id: {id} was not found");
            return Ok(questionAnswer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetAll()
        {
            return Ok(await _questionAnswerService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddQuestionAnswer([ModelBinder(BinderType = typeof(JsonModelBinder))] QuestionAnswer questionAnswer,IFormFile formFile)
        {
            try
            {
                if (questionAnswer == null) return BadRequest("QuestionAnswer was not provided");
                if (questionAnswer.QuestionId == null)
                    return BadRequest("Could not connect question answer to question, because question id was not provided");
                await _questionAnswerService.Add(questionAnswer);
                return Ok(questionAnswer.Id);
            }
            catch (NullReferenceException)
            {
                return NotFound("Question with provided id does not exist or refences to null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestionAnswer(int id)
        {
            var questionAnswerToDelete = await _questionAnswerService.Get(id);
            if (questionAnswerToDelete == null) return NotFound($"QuestionAnswer with id: {id} was not found");
            await _questionAnswerService.Delete(questionAnswerToDelete);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionAnswer>> UpdateQuestionAnswer(int id, QuestionAnswer newQuestionAnswer)
        {
            try
            {
                var questionAnswerToUpdate = await _questionAnswerService.Get(id);
                if (questionAnswerToUpdate == null) return NotFound($"QuestionAnswer with id: {id} was not found");
                return await _questionAnswerService.Update(questionAnswerToUpdate, newQuestionAnswer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpPut("{id}/UploadImage")]
        public async Task<ActionResult> UploadImage(int id, IFormFile formFile)
        {
            try
            {
                if (formFile == null) return BadRequest("To file provided");

                QuestionAnswer? questionAnswer = _questionAnswerService.Get(id).Result;
                if (questionAnswer == null) return NotFound($"No quetion with id: {id} exist!");

                questionAnswer.PhotoName = await FileHandler.UploadFile(_webHostEnvironment, questionAnswer.Question?.Section?.OfflineExamId, formFile, id, 'a');
                await _questionAnswerService.Update(questionAnswer, questionAnswer);

                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest("Unable to upload image");
            }
        }

    }
}
