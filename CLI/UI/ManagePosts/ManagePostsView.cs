using System.Globalization;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView
{
    private readonly IPost postRepository;
    private readonly IComment commentRepository;

    public ManagePostsView(IPost postRepository, IComment commentRepository)
    {
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
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
                    await CreatePostAsync();
                    break;
                case "2":
                    await ViewPostAsync();
                    break;
                case "3":
                    await PostOverviewAsync();
                    break;
                case "4":
                    await AddCommentToPostAsync();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice :( TRY AGAIN MY FRIEND ");
                    break;
            }
        }
    }
    
    private void Menu()
    {
        Console.WriteLine("\n Manage Posts :) HAVE A GREAT DAY");
        Console.WriteLine("1) Create post");
        Console.WriteLine("2) View specific post with comments");
        Console.WriteLine("3) View post overview(id,title)");
        Console.WriteLine("4) add comment to post");
        Console.WriteLine("0) Back");
        Console.Write("Enter choice: ");
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
        Console.WriteLine($"Post created BY {newPost.UserId} {newPost.Title} ");
    }
    
    
    private async Task ViewPostAsync()
    {
        Console.Write("Enter post id: ");
        int? postId = int.Parse(Console.ReadLine());
        if (postId == null)
        {
            Console.WriteLine("Post ID is required. Null will be replace by id 1 ");

        }

        var post = await postRepository.GetSingleAsync(postId??1);
        if (post == null)
        {
            Console.WriteLine("Post not found :( check id and try again");
            return;
        }

        Console.WriteLine($"\n Title: {post.Title}");
        Console.WriteLine($"\n Body: {post.Body}");

        var comments = commentRepository.GetMany().ToList();
        foreach (var c in comments)
        {
            if (!comments.Any())
            {
                Console.WriteLine("Comments not found :( check id and try again");
            }
            if (c.PostId == postId)
            {
                Console.WriteLine($"Comment: {c.Body}");
            }
        }

    }

    private Task PostOverviewAsync()
    {
        var posts = postRepository.GetMany().ToList();
        Console.WriteLine("\n Post Overview:::");
        foreach (var p in posts)
        {
            Console.WriteLine($"Post Id: {p.Id} Title: {p.Title}   User Id: {p.UserId}");
        }
        return Task.CompletedTask;
    }

    public async Task AddCommentToPostAsync()
    {
        
        
        Console.Write("Enter body: ");
        var body = Console.ReadLine() ?? string.Empty;

        Console.Write("(if empty app will set it as 1) Enter post id:  ");
        var postId = int.Parse(Console.ReadLine() ?? "1");
        
        Console.Write("(same as psotId) Enter user id: ");
        var userId = int.Parse(Console.ReadLine() ?? "1");
        Comment comment = new Comment();
        comment.Body = body;
        comment.PostId = postId;
        comment.UserId = userId;
        
        await commentRepository.AddAsync(comment);
        Console.WriteLine("Comment added."); 
    }


    
    

    
   
    
    
    
    
}