using InkHouse.Models;

namespace InkHouse.Services.Base;

public interface IPaintingService
{
    public Task<IEnumerable<Painting>> GetAllPaintingsAsync();
    public Task<Painting> GetPaintingByIdAsync(Guid id);
}
