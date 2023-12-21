using Hero.Bot.Domain.Entities;

namespace Hero.Bot.Domain
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(long id);
        Task Add(User user);
        Task Update(User user);
    }
}
