using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace PriestBlogServer.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : Controller
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public AuthorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var authors = _repository.Author.GetAllAuthors();
                _logger.LogInfo($"Returned all authors from database.");

                var authorsResult = _mapper.Map<IEnumerable<AuthorDto>>(authors);
                return Ok(authorsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorById(id);
                if (author is null)
                {
                    _logger.LogError($"Author with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned author with id: {id}");
                    var authorResult = _mapper.Map<AuthorDto>(author);
                    return Ok(authorResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAuthorById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
