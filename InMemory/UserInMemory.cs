using Entities;
using RepositoryContracts;
namespace InMemory;

public class UserInMemory: IUser
{
    List<User> users = new List<User>();
    public Task<User> AddAsync(User post)
    {
        post.Id = users.Any()
            ? users.Max(p => p.Id) + 1
            : 1;
        users.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(User post)
    {
        User? existingUser = users.SingleOrDefault(p => p.Id == post.Id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(

                $"User with ID '{post.Id}' not found");
        }

        users.Remove(existingUser);
        users.Add(post); 
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(p => p.Id == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException( $"User with ID '{id}' not found");
        } 
        users.Remove(userToRemove); 
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int id)
    {
        User? userToRetrieve = users.SingleOrDefault(p => p.Id == id); 
        if (userToRetrieve is null) 
        { 
            throw new InvalidOperationException($"User with ID '{id}' not found"); 
        } 
        return Task.FromResult(userToRetrieve);
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }
}