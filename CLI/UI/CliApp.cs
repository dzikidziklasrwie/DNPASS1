using RepositoryContracts;

namespace CLI.UI;

public class CliApp
{
    IUser UserRepository { get; set; }
    IComment CommentRepository { get; set; }
    IPost PostRepository { get; set; }
    public CliApp(IUser userRepository,IComment commentRepository, IPost postRepository)
    {
        UserRepository = userRepository;
        CommentRepository = commentRepository;
        PostRepository = postRepository;
    }

    public async Task StartAsync()
    {
        
    }
}