using Entities.Models;

namespace Contracts
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        IEnumerable<Article> ArticlesByAuthor(Guid authorId);
    }
}
