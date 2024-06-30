using InkHouse.Models;
using InkHouse.Repositories.Base;
using InkHouse.Services.Base;

namespace InkHouse.Services;

public class PaintingService : IPaintingService
{
    private readonly IPaintingRepository paintingRepository;

    public PaintingService(IPaintingRepository paintingRepository)
    {
        this.paintingRepository = paintingRepository;
    }

    public async Task CreateNewPaintingAsync(Painting newPainting, IFormFile image)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(newPainting.Name);
        await paintingRepository.CreateAsync(newPainting, image);
    }


    public async Task DeletePaintingById(Guid id)
    {
        await paintingRepository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        var countries = await paintingRepository.GetAllCountriesAsync();
        return countries;
    }

    public async Task<IEnumerable<Painter>> GetAllPaintersAsync()
    {
        return await paintingRepository.GetAllPaintersAsync();
    }

    public async Task<IEnumerable<Painting>> GetAllPaintingsAsync()
    {
        var paintings = await paintingRepository.GetAllAsync();

        return paintings ?? Enumerable.Empty<Painting>();
    }

    public async Task<Painting> GetPaintingByIdAsync(Guid id)
    {
        var painting = await paintingRepository.GetByIdAsync(id);
        return painting;
    }

    public async Task UpdatePaintingAsync(Painting painting)
    {
        await paintingRepository.UpdateAsync(painting);
    }

}
