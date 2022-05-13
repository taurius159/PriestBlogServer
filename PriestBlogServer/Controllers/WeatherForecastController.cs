using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace PriestBlogServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public WeatherForecastController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var spiritualArticles = _repository.Article.FindByCondition(x => x.ArticleType.Equals("Spiritual"));
            var authors = _repository.Author.FindAll();

            return new string[] { "value1", "value2" };
        }
    }
}