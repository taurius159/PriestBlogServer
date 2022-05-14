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
    }
}
