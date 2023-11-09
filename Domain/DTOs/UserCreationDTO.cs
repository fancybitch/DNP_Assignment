
//DTO is retrieve from the user domain only the fields we want
//constructor is used to say what fields user must have after creation

namespace Domain.DTOs;

public class UserCreationDTO
{
    public string UserName { get; }
    public string Password { get; }
    public string Email { get; }

    public UserCreationDTO(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }
}