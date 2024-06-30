namespace InkHouse.Repositories.Base;

public interface ICreateAsync<TEntity>
{
    public Task CreateAsync(TEntity obj, IFormFile image);
}
