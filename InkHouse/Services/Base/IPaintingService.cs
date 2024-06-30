using InkHouse.Models;

namespace InkHouse.Services.Base;

public interface IPaintingService
{
    public Task<IEnumerable<Painting>> GetAllPaintingsAsync();
    public Task<IEnumerable<Country>> GetAllCountriesAsync();
    public Task<IEnumerable<Painter>> GetAllPaintersAsync();
    public Task<Painting> GetPaintingByIdAsync(Guid id);
    public Task DeletePaintingById(Guid id);
    public Task CreateNewPaintingAsync(Painting newPainting, IFormFile image);
    public Task UpdatePaintingAsync(Painting painting);
}
