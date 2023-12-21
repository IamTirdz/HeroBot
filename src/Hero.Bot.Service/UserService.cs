using Hero.Bot.Domain;
using Hero.Bot.Domain.Entities;
using Hero.Bot.Domain.Persistence;

namespace Hero.Bot.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetById(long id)
        {
            return _userRepository.FirstOrDefaultAsync(x => x.Id == id)!;
        }

        public async Task Add(User user)
        {
            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
