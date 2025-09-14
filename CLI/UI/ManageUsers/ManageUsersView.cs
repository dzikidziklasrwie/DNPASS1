

using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private readonly IUser userRepository;

    public ManageUsersView(IUser userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task StartAsync()
    {
        
    }

    
    private async Task CreateUserAsync()
    {
        Console.Write("Enter user name: ");
        var name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter password: ");
        var password = Console.ReadLine() ?? string.Empty;
        User newUser = new User();
        newUser.Username = name;
        newUser.Password = password;
        await userRepository.AddAsync(newUser);
        Console.WriteLine("User created.");
    }
}