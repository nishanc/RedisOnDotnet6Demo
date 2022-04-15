using RedisOnDotnet6Demo.Models;

namespace RedisOnDotnet6Demo.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
    }
}
