using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PriestBlogServer.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ArticleController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllArticles([FromQuery] ArticleParameters articleParameters)
        {
            try
            {
                var articles = _repository.Article.GetArticles(articleParameters);
                _logger.LogInfo($"Returned {articles.Count()} articles from database.");

                var articlesResult = _mapper.Map<IEnumerable<ArticleDto>>(articles);
                return Ok(articlesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllArticles action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "ArticleById")]
        public IActionResult GetArticleById(Guid id)
        {
            try
            {
                var article = _repository.Article.GetArticleById(id);
                if (article is null)
                {
                    _logger.LogError($"Article with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned article with id: {id}");
                    var articleResult = _mapper.Map<ArticleDto>(article);
                    return Ok(articleResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetArticleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateArticle([FromBody] ArticleForCreationDto article)
        {
            try
            {
                if (article is null)
                {
                    _logger.LogError("Article object sent from client is null.");
                    return BadRequest("Article object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid article object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var articleEntity = _mapper.Map<Article>(article);
                _repository.Article.CreateArticle(articleEntity);
                _repository.Save();
                var createdArticle = _mapper.Map<ArticleDto>(articleEntity);
                return CreatedAtRoute("ArticleById", new { id = createdArticle.Id }, createdArticle);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateArticle action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateArticle(Guid id, [FromBody] ArticleForUpdateDto article)
        {
            try
            {
                if (article is null)
                {
                    _logger.LogError("Article object sent from client is null.");
                    return BadRequest("Article object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid article object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var articleEntity = _repository.Article.GetArticleById(id);
                if (articleEntity is null)
                {
                    _logger.LogError($"Article with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(article, articleEntity);
                _repository.Article.UpdateArticle(articleEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateArticle action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(Guid id)
        {
            try
            {
                var article = _repository.Article.GetArticleById(id);
                if (article == null)
                {
                    _logger.LogError($"Article with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Article.DeleteArticle(article);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteArticle action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
