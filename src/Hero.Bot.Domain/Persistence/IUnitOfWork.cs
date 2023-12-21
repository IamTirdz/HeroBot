using Hero.Bot.Domain.Entities;

namespace Hero.Bot.Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<User> Users { get; }
    }
}
