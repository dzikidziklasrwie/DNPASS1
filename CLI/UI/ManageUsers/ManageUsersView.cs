

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
        bool back = false;
        while (!back)
        {
            Menu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await CreateUserAsync();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void Menu()
    {
        Console.WriteLine("\n Manage Users :) HAVE A GREAT DAY ");
        Console.WriteLine("1) Create user");
        Console.WriteLine("0) Back");
        Console.Write("Enter choice: ");
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
        Console.WriteLine($"User created. userid: {newUser.Id}");
    }
}