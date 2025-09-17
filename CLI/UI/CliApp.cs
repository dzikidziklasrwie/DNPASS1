
using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp
{
    private readonly IUser userRepository;
    private readonly IComment commentRepository;
    private readonly IPost postRepository;
    public CliApp(IUser userRepository,IComment commentRepository, IPost postRepository)
    {
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
        this.postRepository = postRepository;
    }

    public async Task StartAsync()
    {
        bool exit = false;

        while (!exit)
        {
            MainMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var userView = new ManageUsersView(userRepository);
                    await userView.StartAsync();
                    break;
                case "2":
                    var postView = new ManagePostsView(postRepository, commentRepository);
                    await postView.StartAsync();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
    private void MainMenu()
    {
        Console.WriteLine("\n Main Menu :) HAVE A GREAT DAY");
        Console.WriteLine("1) Manage users");
        Console.WriteLine("2) Manage posts and comments");
        Console.WriteLine("0) Exit");
        Console.Write("Enter choice: ");
    }
    
}