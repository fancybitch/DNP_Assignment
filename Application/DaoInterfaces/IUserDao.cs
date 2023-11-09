//Class to store the newly created User
//We take a user object and return user object: converting from UserCreationDTO to User

using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> Create(User user);
    Task<User?> GetByUsername(string userName);
    Task<User?> GetByIdAsync(int id);
}