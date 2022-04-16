using RedisOnDotnet6Demo.Models;

namespace RedisOnDotnet6Demo.Data
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetUsersAsync()
        {
            List<User> output = new()
            {
                new() { FirstName = "William", LastName = "Jackson" },
                new() { FirstName = "Maria", LastName = "Moody" },
                new() { FirstName = "Sarah", LastName = "King" },
                new() { FirstName = "Gregory", LastName = "Estrada" },
                new() { FirstName = "Juan", LastName = "Russell" },
                new() { FirstName = "James", LastName = "Bryant" },
                new() { FirstName = "Patrick", LastName = "Mullins" },
                new() { FirstName = "Sandra", LastName = "Fleming" },
                new() { FirstName = "Miguel", LastName = "Ramsey" },
                new() { FirstName = "Monica", LastName = "Howell" }
            };

            await Task.Delay(3000); // simulating data access time

            return output;
        }
    }
}
