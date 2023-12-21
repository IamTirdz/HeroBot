using Hero.Bot.Domain.Entities;
using Hero.Bot.Domain.Persistence;
using Hero.Bot.Infrastructure.Data;

namespace Hero.Bot.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new Repository<User>(_dbContext);
        }
        
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IRepository<User> Users { get; }
    }
}
