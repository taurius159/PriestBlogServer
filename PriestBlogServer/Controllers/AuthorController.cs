using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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
        [HttpGet("{id}", Name  = "AuthorById")]
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

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            try
            {
                if (author is null)
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid author object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var authorEntity = _mapper.Map<Author>(author);
                _repository.Author.CreateAuthor(authorEntity);
                _repository.Save();
                var createdAuthor = _mapper.Map<AuthorDto>(authorEntity);
                return CreatedAtRoute("AuthorById", new { id = createdAuthor.Id }, createdAuthor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            try
            {
                if (author is null)
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid author object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var authorEntity = _repository.Author.GetAuthorById(id);
                if (authorEntity is null)
                {
                    _logger.LogError($"Author with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(author, authorEntity);
                _repository.Author.UpdateAuthor(authorEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
