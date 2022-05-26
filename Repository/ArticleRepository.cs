using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Article> ArticlesByAuthor(Guid authorId)
        {
            return FindByCondition(a => a.AuthorId.Equals(authorId)).ToList();
        }

        public void CreateArticle(Article article)
        {
            Create(article);
        }

        public void DeleteArticle(Article article)
        {
            Delete(article);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return FindAll()
                .ToList();
        }

        public Article GetArticleById(Guid articleId)
        {
            return FindByCondition(article => article.Id.Equals(articleId))
           .FirstOrDefault();
        }

        public void UpdateArticle(Article article)
        {
            Update(article); 
        }
    }
}
