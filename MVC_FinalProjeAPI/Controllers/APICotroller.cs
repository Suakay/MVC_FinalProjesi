using Microsoft.AspNetCore.Mvc;
using MVCFinalProje.Infrastructure.Repositories.AthourRepository;

namespace MVC_FinalProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorRepository.GetAllAsync();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
          
        }
    }
}