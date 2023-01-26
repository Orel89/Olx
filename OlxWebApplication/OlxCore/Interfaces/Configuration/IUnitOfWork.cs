using OlxCore.Interfaces.Repository;

namespace OlxCore.Interfaces.Configuration
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        ISubcategoryRepository SubcategoryRepository { get; }

        IAnnouncementRepository AnnouncementRepository { get; }

        Task<bool> SaveChangesAsync();

        bool SaveChanges();
    }
}
