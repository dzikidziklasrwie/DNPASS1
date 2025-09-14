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
        
    }
    
    private void ShowMainMenu()
    {
        Console.WriteLine("\n Main Menu :)");
        Console.WriteLine("1) Manage users");
        Console.WriteLine("2) Manage posts");
        Console.WriteLine("3) Manage comments");
        Console.WriteLine("0) Exit");
        Console.Write("Enter choice: ");
    }
    
}