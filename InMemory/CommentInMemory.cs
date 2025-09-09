using Entities;
using RepositoryContracts;
namespace InMemory;

public class CommentInMemory: IComment
{
    List<Comment> comments = new List<Comment>();
    public Task<Comment> AddAsync(Comment post)
    {
        post.UserId = comments.Any()
            ? comments.Max(p => p.UserId) + 1
            : 1;
        comments.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Comment post)
    {
        Comment? existingUser = comments.SingleOrDefault(p => p.UserId == post.UserId);
        if (existingUser is null)
        {
            throw new InvalidOperationException(

                $"Comment with ID '{post.UserId}' not found");
        }

        comments.Remove(existingUser);
        comments.Add(post); 
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Comment? userToRemove = comments.SingleOrDefault(p => p.UserId == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException( $"Comment with ID '{id}' not found");
        } 
        comments.Remove(userToRemove); 
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(int id)
    {
        Comment? userToRetrieve = comments.SingleOrDefault(p => p.UserId == id); 
        if (userToRetrieve is null) 
        { 
            throw new InvalidOperationException($"Comment with ID '{id}' not found"); 
        } 
        return Task.FromResult(userToRetrieve);
    }

    public IQueryable<Comment> GetMany()
    {
        return comments.AsQueryable();
    }
}