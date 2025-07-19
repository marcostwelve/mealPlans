using Repository.Model.Dto.Auth.Dtos;

namespace Repository.Repository.IUserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveAsync();
    }
}
