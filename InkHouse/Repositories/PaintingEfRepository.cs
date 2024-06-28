using InkHouse.Data;
using InkHouse.Models;
using InkHouse.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InkHouse.Repositories;

public class PaintingEfRepository : IPaintingRepository
{
    private readonly InkHouseDbContext dbContext;

    public PaintingEfRepository(InkHouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<IEnumerable<Painting>> GetAllAsync()
    {
        return await dbContext.Paintings.Include(p => p.Painter).ToListAsync();
    }

    public async Task<Painting> GetByIdAsync(Guid id)
    {
        var paintings = await this.GetAllAsync();
        var painting = paintings?.FirstOrDefault(p => p.PaintingId == id);
        return painting ?? throw new Exception("Not Found");
    }
}
