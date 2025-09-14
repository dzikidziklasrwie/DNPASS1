using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView
{
    private readonly IPost postRepository;
    public ManagePostsView(IPost postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task StartAsync()
    {
        
    }

    private async Task CreatePostAsync()
    {
        Console.Write("Enter title: ");
        var title = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter body: ");
        var body = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter user id: ");
        var userId = int.Parse(Console.ReadLine() ?? "0");
        Post newPost = new();
        newPost.Title = title;
        newPost.Body = body;
        newPost.UserId = userId;
        await postRepository.AddAsync(newPost);
        Console.WriteLine("Post created.");
    }
}