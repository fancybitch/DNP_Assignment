using Domain.Models;
namespace FileData;

//Here we create a collection, that is a container, which stores
//users and posts. It works like database table
public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}