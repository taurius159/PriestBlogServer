using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Author> GetAuthors(AuthorParameters authorParameters)
        {
            return FindAll()
                .OrderBy(author => author.Name)
                .Skip((authorParameters.PageNumber - 1) * authorParameters.PageSize)
                .Take(authorParameters.PageSize)
                .ToList();
        }

        public Author GetAuthorById(Guid authorId)
        {
            return FindByCondition(author => author.Id.Equals(authorId))
            .FirstOrDefault();
        }
        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            Update(author);
        }
        public void DeleteAuthor(Author author)
        {
            Delete(author);
        }
    }
}
