using RedisOnDotnet6Demo.Models;

namespace RedisOnDotnet6Demo.Data
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetUsersAsync()
        {
            List<User> output = new()
            {
                new() { FirstName = "Tim", LastName = "Corey" },
                new() { FirstName = "Sue", LastName = "Storm" },
                new() { FirstName = "Jane", LastName = "Jones" }
            };

            await Task.Delay(3000); // simulating data access time

            return output;
        }
    }
}
