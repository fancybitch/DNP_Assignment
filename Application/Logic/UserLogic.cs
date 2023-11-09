//Class to create user
//User DAO received through constructor dependency injection
//Logic knows only about DAO interface, but not its implementation

//We verify that user is not taken
//ValidateData checkes rules of the username
using Application.DaoInterfaces;


using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? existing = await userDao.GetByUsername(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.UserName,
            Password = dto.Password,
            Email = dto.Email
        };
    
        User created = await userDao.Create(toCreate); //new user is created, with ID too that is generetaed in Data layer and handed over to DAO for storage
    
        return created;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsername(username);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }


    private static void ValidateData(UserCreationDTO userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;
        string email = userToCreate.Email;

        if (string.IsNullOrEmpty(userName))
            throw new Exception("Username is required!");

        if (userName.Length < 3 || userName.Length > 15)
            throw new Exception("Username must be between 3 and 15 characters!");

        if (string.IsNullOrEmpty(password))
            throw new Exception("Password is required!");

        if (password.Length < 8 || password.Length > 20)
            throw new Exception("Password must be between 8 and 20 characters!");

        if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            throw new Exception("Password must contain at least one capital letter and one number!");

        if (string.IsNullOrEmpty(email))
            throw new Exception("Email is required!");

        if (!email.Contains("@"))
            throw new Exception("Email must contain the @ symbol!");
    }
}