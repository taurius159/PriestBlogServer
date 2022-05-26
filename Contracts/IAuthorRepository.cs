using Entities.Models;

namespace Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        IEnumerable<Author> GetAuthors(AuthorParameters authorParameters);
        Author GetAuthorById(Guid authorId);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
