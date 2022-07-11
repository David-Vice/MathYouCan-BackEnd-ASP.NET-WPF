using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IQuestionService _questionService;

        public SectionController(ISectionService sectionService, IQuestionService questionService)
        {
            _sectionService = sectionService;
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetById(int id)
        {
            var section = await _sectionService.Get(id);
            if (section == null) return NotFound($"Section with id: {id} was not found");
            return Ok(section);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetAll()
        {
            return Ok(await _sectionService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> CreateSection(Section section, int questionsNumber,int answersNumber)
        {
            try
            {
                if (section == null) return BadRequest("Section was not provided");
                if (section.OfflineExamId == null)
                    return BadRequest("Could not connect section to exam, because exam id was not provided");
                if (questionsNumber <=0)
                    return BadRequest("Number of questions cannot be less than 1");
                if (answersNumber <= 1)
                    return BadRequest("Number of answers cannot be less than 2");
                await _sectionService.Add(section);

                for (int i = 0; i < questionsNumber; i++)
                {
                    Question q = new Question() { Type = 0, PhotoName = "", QuestionContent = "", Text = "", SectionId = section.Id };
                    await _questionService.Add(q,answersNumber);
                }

                return Ok(section.Id);
            }
            catch (NullReferenceException)
            {
                return NotFound("Exam with provided id does not exist or refences to null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSection(int id)
        {
            var sectionToDelete = await _sectionService.Get(id);
            if (sectionToDelete == null) return NotFound($"Section with id: {id} was not found");

            await _sectionService.Delete(sectionToDelete);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Section>> UpdateSection(int id, Section newSection)
        {
            try
            {
                var sectionToUpdate = await _sectionService.Get(id);
                if (sectionToUpdate == null) return NotFound($"Section with id: {id} was not found");
                return await _sectionService.Update(sectionToUpdate, newSection);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
