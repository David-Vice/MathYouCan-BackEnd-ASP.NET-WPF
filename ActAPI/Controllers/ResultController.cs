using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ActAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetAll()
        {
            return Ok(await _resultService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetById(int id)
        {
            var result = await _resultService.Get(id);
            if (result == null)
            {
                return NotFound($"Result with id {id} was not found");
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("Grade")]
        public async Task<ActionResult<Result>> GetGradeByCorrectAnswers(int sectionId, int correctAnswers)
        {
            int? result = _resultService.GetGradeByCorrectAnswers(sectionId, correctAnswers);
            if (result == null)
            {
                return NotFound($"Grade was not found");
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Result result)
        {
            if (result == null)
            {
                return BadRequest("Result is empty");
            }

            await _resultService.Add(result);
            return Ok(result.Id);
        }

        [HttpPost]
        [Route("AddTable")]
        public async Task<ActionResult> AddTable(int sectionId, int tableSize)
        {
            try
            {
                await _resultService.AddTable(sectionId,tableSize);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error on adding table!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> Update(int id, Result result)
        {
            try
            {
                var itemToUpdate = await _resultService.Get(id);
                if (itemToUpdate == null)
                    return NotFound($"Result with id {id} was not found");

                return await _resultService.Update(itemToUpdate, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
