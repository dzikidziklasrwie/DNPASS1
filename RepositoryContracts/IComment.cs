using Entities;

namespace RepositoryContracts;

public interface IComment
{
    Task<Comment> AddAsync(Comment post);
    Task UpdateAsync(Comment post); 
    Task DeleteAsync(int id); 
    Task<Comment> GetSingleAsync(int id); 
    IQueryable<Comment> GetMany();
}