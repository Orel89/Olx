using OlxCore.Interfaces.Repository;

namespace OlxCore.Interfaces.Configuration
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        Task CompleteAsync();

        void Dispose();
    }
}
