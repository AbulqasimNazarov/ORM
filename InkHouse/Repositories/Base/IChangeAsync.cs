using InkHouse.Models;

namespace InkHouse.Repositories.Base;

public interface IChangeAsync<TEntity>
{
    public Task UpdateAsync(TEntity painting);
}
