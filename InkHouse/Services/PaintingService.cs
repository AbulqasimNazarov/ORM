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
}
