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

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return await dbContext.Countries.ToListAsync();
    }

    public async Task CreateAsync(Painting obj, IFormFile image)
    {
        obj.PaintingId = Guid.NewGuid();

        var extension = new FileInfo(image.FileName).Extension[1..];
        obj.Image = $"Assets/PaintingImg/{obj.PaintingId}.{extension}";

        using var newFileStream = System.IO.File.Create(obj.Image);
        await image.CopyToAsync(newFileStream);

        await dbContext.Paintings.AddAsync(obj);
        await dbContext.SaveChangesAsync();
    }


    public async Task DeleteByIdAsync(Guid id)
    {
        var painting = await dbContext.Paintings.FindAsync(id);
        if (painting != null)
        {
            dbContext.Paintings.Remove(painting);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Painting>> GetAllAsync()
    {

        var paintings = await dbContext.Paintings
                                          .Include(p => p.Painter)
                                          .ThenInclude(p => p.Country)
                                          .ToListAsync();

        return paintings;


    }

    public async Task<Painting> GetByIdAsync(Guid id)
    {

        var paintings = await this.GetAllAsync();
        var painting = paintings?.FirstOrDefault(p => p.PaintingId == id);
        return painting ?? throw new Exception("Not Found");
    }

    public async Task UpdateAsync(Painting painting)
    {
        dbContext.Paintings.Update(painting);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Painter>> GetAllPaintersAsync()
    {
        return await dbContext.Painters.ToListAsync();
    }

}
