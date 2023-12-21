using Hero.Bot.Domain.Persistence;
using Hero.Bot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hero.Bot.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbSet<TEntity> _entities;

        public Repository(AppDbContext dbContext)
        {
            _entities = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<TEntity> entity)
        {
            await _entities.AddRangeAsync(entity);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void RemoveAll()
        {
            _entities.RemoveRange(_entities);
        }

        public async Task<IEnumerable<TEntity>> ToListAsync(Func<TEntity, bool> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(e => filter(e)).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(e => filter(e), cancellationToken);
        }
    }
}
