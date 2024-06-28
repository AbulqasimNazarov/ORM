using InkHouse.Models;

namespace InkHouse.Repositories.Base;

public interface IGetAsync<TEntity>
{
     public Task<IEnumerable<Painting>> GetAllAsync();  
     public Task<Painting> GetByIdAsync(Guid id);  
}
