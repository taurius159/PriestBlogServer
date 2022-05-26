using Entities.Models;

namespace Contracts
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        IEnumerable<Article> ArticlesByAuthor(Guid authorId);
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(Guid articleId);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);

    }
}
