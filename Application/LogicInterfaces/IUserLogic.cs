//the method creates a user
//interface is the access point to the domain logic
//the return type task<user> because we want to do work asynchronously

using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDTO userToCreate);
    Task<User> ValidateUser(string username, string password);
}