using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Core;
using System;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        [HttpGet("questionType/{questionType}")]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetAllQuestions(string questionType)
        {
            var questions = await _questionRepository.GetQuestionsAsync(questionType);
            return Ok(questions);
        }
    }
}
