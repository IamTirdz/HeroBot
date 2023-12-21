namespace Hero.Bot.Domain.Persistence
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void RemoveAll();
        Task<IEnumerable<TEntity>> ToListAsync(Func<TEntity, bool> filter, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> filter, CancellationToken cancellationToken = default);
    }
}
