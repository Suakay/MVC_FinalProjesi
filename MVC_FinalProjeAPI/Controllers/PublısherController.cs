using Microsoft.AspNetCore.Mvc;
using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastructure.Repositories.AthourRepository;
using MVCFinalProjeBusiness.Services.PubllısherServices;

namespace MVC_FinalProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublısherController : ControllerBase
    {



        private readonly PublisherService _publısherService;

        public PublısherController(IPublısherService publısherService)
        {
            _publısherService = publısherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _publısherService.GetAllAsync();

            if (result is null)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }


}
