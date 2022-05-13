namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Author { get; }
        IArticleRepository Article { get; }
        void Save();
    }
}
