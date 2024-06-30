namespace InkHouse.Repositories.Base;

public interface IDeleteAsync
{
    public Task DeleteByIdAsync(Guid id);
}
