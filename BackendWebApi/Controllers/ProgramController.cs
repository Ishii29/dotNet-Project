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
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _progrmRepository;
        public ProgramController(IProgramRepository progrmRepository)
        {
            this._progrmRepository = progrmRepository;
        }

        [HttpGet("employer/{employerID}")]
        public async Task<ActionResult<IEnumerable<ProgramsModel>>> GetAllProgram(string employerID)
        {
            var programs = await _progrmRepository.GetProgramsAsync(employerID);
            return Ok(programs);
        }
    }
}
