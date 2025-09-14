using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ManageCommentsView
{
    private readonly IComment commentRepository;

    public ManageCommentsView(IComment commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async Task StartAsync()
    {
        
    }
    
    private async Task CreateCommentAsync()
    {
        Console.Write("Enter body: ");
        var body = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter user id: ");
        var userId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter post id: ");
        var postId = int.Parse(Console.ReadLine() ?? "0");
        Comment comment = new Comment();
        comment.Body = body;
        comment.UserId = userId;
        
        await commentRepository.AddAsync(comment);
        Console.WriteLine("Comment added.");
    }
    
}