using BackendWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;

namespace BackendWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationController(IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
        }

        [HttpGet("application/{applicationID}")]
        public async Task<ActionResult<IEnumerable<ApplicationModel>>> GetAllApplication(string applicationID)
        {
            var applications = await _applicationRepository.GetApplicationAsync(applicationID);
            return Ok(applications);
        }
    }
}
