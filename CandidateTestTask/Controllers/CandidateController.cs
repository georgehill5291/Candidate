using CandidateTestTask.Custom;
using CandidateTestTask.Models;
using CandidateTestTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {

        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateService _candidateService;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        [CustomModelValidate]
        [HttpPost(Name = "Create")]
        public IActionResult Create([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var csv = _candidateService.Create(candidate);
            return Ok(candidate);
        }
    }
}