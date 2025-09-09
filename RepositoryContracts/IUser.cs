using Entities;

namespace RepositoryContracts;

public interface IUser
{
    Task<User> AddAsync(User post);
    Task UpdateAsync(User post); 
    Task DeleteAsync(int id); 
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetMany();
}