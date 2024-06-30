using InkHouse.Models;

namespace InkHouse.Repositories.Base;

public interface IGetAsync<TEntity>
{
     public Task<IEnumerable<TEntity>> GetAllAsync();  
     public Task<TEntity> GetByIdAsync(Guid id); 
     public Task<IEnumerable<Country>> GetAllCountriesAsync();
     public Task<IEnumerable<Painter>> GetAllPaintersAsync();
}
