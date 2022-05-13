using Entities.Models;

namespace Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(Guid authorId);
    }
}
